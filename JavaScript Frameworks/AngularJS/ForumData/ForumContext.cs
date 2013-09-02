using ForumModels;
namespace ForumData
{
    using System;
    using System.Data.Entity;
    using ForumModels;

    public class ForumContext : DbContext
    {
        public ForumContext()
            : base("ForumDatabase")
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
