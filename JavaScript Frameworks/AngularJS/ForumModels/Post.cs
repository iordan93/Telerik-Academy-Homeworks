namespace ForumModels
{
    using System;

    public class Post
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string Content { get; set; }

        public virtual Category Category { get; set; }
    }
}
