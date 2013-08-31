namespace Forum.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using Forum.Attributes;
    using Forum.Models;
    using ForumData;
    using ForumModels;

    public class PostsController : BaseApiController
    {
        // GET api/posts
        [HttpGet]
        public HttpResponseMessage GetAllPosts([ValueProvider(typeof(HeaderValueProviderFactory<string>))]
                                               string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    ForumContext context = new ForumContext();
                    using (context)
                    {
                        UsersController.GetUserBySessionKey(context, sessionKey);
                        var contextPosts = GetAllPosts(context)
                                                               .OrderByDescending(p => p.CreationDate);

                        HashSet<PostGetModel> postModels = new HashSet<PostGetModel>();
                        foreach (var post in contextPosts)
                        {
                            var currentPost = PostGetModel.FromPost(post);
                            postModels.Add(currentPost);
                        }

                        return this.Request.CreateResponse(HttpStatusCode.OK, postModels);
                    }
                });

            return responseMessage;
        }

        // GET api/posts/5
        [HttpGet]
        public HttpResponseMessage GetPostById(
            int postId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    ForumContext context = new ForumContext();
                    using (context)
                    {
                        UsersController.GetUserBySessionKey(context, sessionKey);
                        var contextPost = GetAllPosts(context)
                            .FirstOrDefault(p => p.Id == postId);
                        if (contextPost == null)
                        {
                            throw new ArgumentNullException("The post with the given ID does not exist.");
                        }

                        var post = PostGetModel.FromPost(contextPost);

                        return this.Request.CreateResponse(HttpStatusCode.OK, post);
                    }
                });

            return responseMessage;
        }

        // GET api/posts?tags=web,webapi
        [HttpGet]
        public HttpResponseMessage GetPostsByTags(
            string tags,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    ForumContext context = new ForumContext();
                    UsersController.GetUserBySessionKey(context, sessionKey);
                    string[] tagsSplit = tags.Split(',');

                    HashSet<PostGetModel> postModels = new HashSet<PostGetModel>();

                    var contextPosts = GetAllPosts(context);
                    contextPosts = contextPosts
                        .OrderByDescending(p => p.CreationDate);

                    foreach (var tag in tagsSplit)
                    {
                        contextPosts = contextPosts
                            .Where(p => p.Tags.Any(t => t.Name == tag));
                    }

                    foreach (var post in contextPosts)
                    {
                        var currentPost = PostGetModel.FromPost(post);
                        if (!postModels.Any(p => p.Id == currentPost.Id))
                        {
                            postModels.Add(currentPost);
                        }
                    }

                    return this.Request.CreateResponse(HttpStatusCode.OK, postModels);
                });

            return responseMessage;
        }

        // POST api/posts/5/comment
        [HttpPost]
        [ActionName("comment")]
        public HttpResponseMessage AddComment(
            int postId,
            [FromBody]
            CommentCreateModel commentModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    ForumContext context = new ForumContext();
                    var user = UsersController.GetUserBySessionKey(context, sessionKey);
                    var post = context.Posts.Find(postId);
                    if (post == null)
                    {
                        throw new ArgumentNullException("The post does not exist.");
                    }

                    Comment commentToAdd = new Comment()
                    {
                        Author = user,
                        CreationDate = DateTime.Now,
                        Text = commentModel.Text,
                        Post = post
                    };
                    context.Comments.Add(commentToAdd);
                    context.SaveChanges();

                    return this.Request.CreateResponse(HttpStatusCode.OK);
                });

            return responseMessage;
        }

        // POST api/posts
        [HttpPost]
        public HttpResponseMessage CreatePost(
            PostCreateModel postModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    ForumContext context = new ForumContext();
                    using (context)
                    {
                        var user = UsersController.GetUserBySessionKey(context, sessionKey);
                        IEnumerable<string> titleToTags = postModel.Title.Split(' ').Select(t => t.ToLower());
                        Post postToAdd = new Post()
                        {
                            Title = postModel.Title,
                            Author = user,
                            CreationDate = DateTime.Now,
                            Text = postModel.Text,
                        };

                        postToAdd.Tags = (from tag in postModel.Tags
                                          select new Tag()
                                          {
                                              Name = tag,
                                              Posts = new List<Post>() { postToAdd }
                                          })
                                            .ToList();

                        foreach (var tag in titleToTags)
                        {
                            if (!postToAdd.Tags.Select(t => t.Name).Contains(tag))
                            {
                                postToAdd.Tags.Add(new Tag()
                                {
                                    Name = tag,
                                    Posts = new List<Post>() { postToAdd }
                                });
                            }
                        }

                        context.Posts.Add(postToAdd);
                        context.SaveChanges();

                        PostAddedModel resultModel = new PostAddedModel()
                        {
                            Id = postToAdd.Id,
                            Title = postToAdd.Title
                        };

                        return this.Request.CreateResponse(HttpStatusCode.Created, resultModel);
                    }
                });

            return responseMessage;
        }

        private IQueryable<Post> GetAllPosts(ForumContext context)
        {
            var contextPosts = context.Posts
                                      .Include(p => p.Author)
                                      .Include(p => p.Tags)
                                      .Include(p => p.Comments)
                                      .Include(p => p.Comments
                                                     .Select(c => c.Author));

            return contextPosts;
        }
    }
}