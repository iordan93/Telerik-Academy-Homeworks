namespace _3.DropboxPhotos
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Spring.IO;
    using Spring.Social.Dropbox.Api;
    using Spring.Social.Dropbox.Connect;
    using Spring.Social.OAuth1;

    public class DropboxPhotos
    {
        private const string DropboxAppKey = "j3xnnasbf08ew4j";
        private const string DropboxAppSecret = "v41riq2bqrkl1oz";

        private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

        static void Main()
        {
            DropboxServiceProvider dropboxServiceProvider = new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.Full);

            if (!File.Exists(OAuthTokenFileName))
            {
                AuthorizeAppOAuth(dropboxServiceProvider);
            }
            OAuthToken oauthAccessToken = LoadOAuthToken();

            IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

            DropboxProfile profile = dropbox.GetUserProfileAsync().Result;
            Console.WriteLine("Hi " + profile.DisplayName + "!");

            Console.WriteLine("Enter the name of the folder to create: ");
            string newFolderName = Console.ReadLine();
            Entry createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;
            Console.WriteLine("Created folder: {0}", createFolderEntry.Path);

            UploadFile(newFolderName, "Boston City Flow.jpg", dropbox);
            UploadFile(newFolderName, "Costa Rican Frog.jpg", dropbox);
            UploadFile(newFolderName, "Pensive Parakeet.jpg", dropbox);
        }

        private static void UploadFile(string newFolderName, string fileName, IDropbox dropbox)
        {
            Entry uploadFileEntry = dropbox.UploadFileAsync(
                new FileResource("../../" + fileName),
                "/" + newFolderName + "/" + fileName).Result;
            Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);

            DropboxLink sharedUrl = dropbox.GetShareableLinkAsync(uploadFileEntry.Path).Result;
            Process.Start(sharedUrl.Url);
        }

        private static OAuthToken LoadOAuthToken()
        {
            string[] lines = File.ReadAllLines(OAuthTokenFileName);
            OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
            return oauthAccessToken;
        }

        private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
        {
            Console.Write("Getting request token...");
            OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
            Console.WriteLine("Done.");

            OAuth1Parameters parameters = new OAuth1Parameters();
            string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
                oauthToken.Value, parameters);
            Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
            Process.Start(authenticateUrl);
            Console.Write("Press [Enter] when authorization attempt has succeeded.");
            Console.ReadLine();

            Console.Write("Getting access token...");
            AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
            OAuthToken oauthAccessToken =
                dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
            Console.WriteLine("Done.");

            string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
            File.WriteAllLines(OAuthTokenFileName, oauthData);
        }
    }
}