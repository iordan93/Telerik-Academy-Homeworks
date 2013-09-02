using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Forum.Models;
using ForumModels;
using ForumData;

namespace Forum.Controllers
{
    public class PostsController : ApiController
    {
        private readonly ForumContext db = new ForumContext();

        // GET api/Posts
        public HttpResponseMessage GetPosts()
        {
            var allPosts = db.Posts.ToList();
            var postModels = new HashSet<PostGetModel>();
            foreach (var post in allPosts)
            {
                postModels.Add(PostGetModel.FromPost(post));
            }

            return Request.CreateResponse(HttpStatusCode.OK, postModels);
        }

        // POST api/Posts
        public HttpResponseMessage PostPost(PostCreateModel postModel)
        {
            if (ModelState.IsValid)
            {
                var category = db.Categories.FirstOrDefault(c => c.Name == postModel.Category);
                if (category == null)
                {
                    category = db.Categories.Add(new Category()
                    {
                        Name = postModel.Category
                    });

                    db.SaveChanges();
                }

                var post = new Post()
                {
                    CreationDate = DateTime.Now,
                    Content = postModel.Content,
                    Category = category
                };

                db.Posts.Add(post);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, postModel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = post.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}