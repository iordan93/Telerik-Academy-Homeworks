using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ForumModels;

namespace Forum.Models
{
    [DataContract]
    public class PostGetModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        public static PostGetModel FromPost(Post post)
        {
            return new PostGetModel()
            {
                Id = post.Id,
                Content = post.Content,
                Category = post.Category.Name
            };
        }
    }
}