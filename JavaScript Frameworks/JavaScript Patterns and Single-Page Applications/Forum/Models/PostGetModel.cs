namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using ForumModels;

    [DataContract]
    public class PostGetModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime CreationDate { get; set; }

        [DataMember(Name = "postedBy")]
        public string Author { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "tags")]
        public ICollection<string> Tags { get; set; }

        [DataMember(Name = "comments")]
        public ICollection<CommentGetModel> Comments { get; set; }

        internal static PostGetModel FromPost(Post newPost)
        {
            PostGetModel modelPost = new PostGetModel()
            {
                Id = newPost.Id,
                Author = newPost.Author.DisplayName,
                CreationDate = newPost.CreationDate,
                Title = newPost.Title,
                Text = newPost.Text,
                Tags = newPost.Tags
                              .OrderBy(t => t.Name)
                              .Select(t => t.Name)
                              .ToList(),
            };

            if (newPost.Comments != null)
            {
                modelPost.Comments =
                    (from comment in newPost.Comments
                     select new CommentGetModel()
                     {
                         Author = comment.Author.DisplayName,
                         CreationDate = comment.CreationDate,
                         Text = comment.Text
                     })
                     .OrderByDescending(c => c.CreationDate)
                     .ToList();
            }

            return modelPost;
        }
    }
}