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

    public class TagsController :BaseApiController
    {
        // GET api/tags
        [HttpGet]
        public HttpResponseMessage GetAllTags(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    ForumContext context = new ForumContext();
                    using (context)
                    {
                        HashSet<TagGetModel> tagModels = new HashSet<TagGetModel>();
                        var contextTags = GetAllTags(context)
                                                             .OrderBy(t => t.Name);
                        foreach (var tag in contextTags)
                        {
                            tagModels.Add(TagGetModel.FromTag(tag));
                        }

                        return this.Request.CreateResponse(HttpStatusCode.OK, tagModels);
                    }
                });

            return responseMessage;
        }

        private IQueryable<Tag> GetAllTags(ForumContext context)
        {
            var contextTags = context.Tags
                                     .Include(t => t.Posts)
                                     .Include(t => t.Posts
                                                    .Select(p => p.Author))
                                     .Include(t => t.Posts
                                                    .Select(p => p.Comments))
                                     .Include(t => t.Posts
                                                    .Select(p => p.Comments
                                                                  .Select(c => c.Author)));

            return contextTags;
        }
    }
}
