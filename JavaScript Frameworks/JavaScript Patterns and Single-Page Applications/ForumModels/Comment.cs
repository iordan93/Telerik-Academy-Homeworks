namespace ForumModels
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public User Author { get; set; }

        public Post Post { get; set; }

        [Column(TypeName = "ntext")]
        public string Text { get; set; }
    }
}
