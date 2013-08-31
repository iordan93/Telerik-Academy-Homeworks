namespace Forum.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using ForumData;
    using ForumModels;
    using Forum.Attributes;
    using Forum.Models;

    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const int MinDisplayNameLength = 6;
        private const int MaxDisplayNameLength = 30;
        private const int Sha1AuthCodeLength = 40;
        private const int SessionKeyLength = 50;
        private const string ValidUsernameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890_.";
        private const string ValidDisplayNameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_- .";
        private const string SessionKeyCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static readonly Random random = new Random();

        // POST api/users/register
        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser(UserRegisteredModel userModel)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    ForumContext context = new ForumContext();
                    using (context)
                    {
                        this.ValidateUsername(userModel.Username);
                        this.ValidateDisplayName(userModel.DisplayName);
                        this.ValidateAuthCode(userModel.AuthCode);

                        string usernameToLower = userModel.Username.ToLower();
                        string displayNameToLower = userModel.DisplayName.ToLower();

                        User user = context.Users
                                           .FirstOrDefault(u => u.Username.ToLower() == usernameToLower ||
                                                                u.DisplayName == displayNameToLower);
                        if (user != null)
                        {
                            throw new InvalidOperationException("The user already exists.");
                        }

                        user = new User()
                        {
                            Username = usernameToLower,
                            DisplayName = userModel.DisplayName,
                            AuthCode = userModel.AuthCode
                        };
                        context.Users.Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();

                        UserLoggedInModel loggedInUser = new UserLoggedInModel()
                        {
                            DisplayName = user.DisplayName,
                            SessionKey = user.SessionKey
                        };

                        return this.Request.CreateResponse(HttpStatusCode.Created, loggedInUser);
                    }
                });

            return responseMessage;
        }

        // POST api/users/login
        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser(UserRegisteredModel userModel)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    ForumContext context = new ForumContext();
                    using (context)
                    {
                        this.ValidateUsername(userModel.Username);
                        this.ValidateAuthCode(userModel.AuthCode);

                        string usernameToLower = userModel.Username.ToLower();

                        User existingUser = context.Users
                                                   .FirstOrDefault(u => u.Username.ToLower() == usernameToLower);
                        if (existingUser == null)
                        {
                            throw new ArgumentNullException("The user does not exist.");
                        }

                        if (existingUser.SessionKey == null)
                        {
                            existingUser.SessionKey = this.GenerateSessionKey(existingUser.Id);
                            context.SaveChanges();
                        }

                        UserLoggedInModel loggedUser = new UserLoggedInModel()
                        {
                            DisplayName = existingUser.DisplayName,
                            SessionKey = existingUser.SessionKey
                        };

                        return this.Request.CreateResponse(HttpStatusCode.Created, loggedUser);
                    }
                });

            return responseMessage;
        }

        // POST api/users/logout
        [HttpPost]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    ForumContext context = new ForumContext();
                    using (context)
                    {
                        User existingUser = context.Users
                                                   .FirstOrDefault(u => u.SessionKey == sessionKey);
                        if (existingUser == null)
                        {
                            throw new ArgumentNullException("The user does not exist or is already logged out.");
                        }

                        existingUser.SessionKey = null;
                        context.SaveChanges();
                        
                        return this.Request.CreateResponse(HttpStatusCode.OK);
                    }
                });

            return responseMessage;
        }

        internal static User GetUserBySessionKey(ForumContext context, string sessionKey)
        {
            var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
            if (user == null)
            {
                throw new ArgumentNullException("user", "The user does not exist or is already logged out.");
            }

            return user;
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("The username must not be null.");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException("username", string.Format("The username must be at least {0} symbols.", MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException("username", string.Format("The username must be at most {0} symbols.", MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentException("The username must contain only Latin characters, digits, underscores and dots.");
            }
        }

        private void ValidateDisplayName(string displayName)
        {
            if (displayName == null)
            {
                throw new ArgumentNullException("The display name must not be null.");
            }
            else if (displayName.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException("displayName", string.Format("The display name must be at least {0} symbols.", MinDisplayNameLength));
            }
            else if (displayName.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException("displayName", string.Format("The display name must be at most {0} symbols.", MaxDisplayNameLength));
            }
            else if (displayName.Any(ch => !ValidDisplayNameCharacters.Contains(ch)))
            {
                throw new ArgumentException("The display name must contain only Latin characters, digits, spaces, underscores, dashes, spaces and dots.");
            }
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null)
            {
                throw new ArgumentNullException("The authentication code must not be null.");
            }
            else if (authCode.Length != Sha1AuthCodeLength)
            {
                throw new ArgumentException("The authentication code must be encrypted with SHA-1.");
            }
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder sessionKey = new StringBuilder();
            sessionKey.Append(userId);
            while (sessionKey.Length < SessionKeyLength)
            {
                int index = random.Next(SessionKeyCharacters.Length);
                sessionKey.Append(SessionKeyCharacters[index]);
            }

            return sessionKey.ToString();
        }
    }
}