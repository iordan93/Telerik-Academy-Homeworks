namespace ForumData
{
    using System;
    using System.Data.Entity;
    using ForumModels;

    public class ForumContext : DbContext
    {
        public ForumContext()
            : base("Forum")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
