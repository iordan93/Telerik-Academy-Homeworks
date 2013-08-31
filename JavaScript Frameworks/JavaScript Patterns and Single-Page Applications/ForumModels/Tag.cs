namespace ForumModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
