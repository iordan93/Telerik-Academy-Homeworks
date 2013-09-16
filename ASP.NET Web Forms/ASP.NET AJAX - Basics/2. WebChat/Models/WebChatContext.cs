namespace _2.WebChat.Models
{
    using System;
    using System.Data.Entity;

    public class WebChatContext : DbContext
    {
        public WebChatContext()
            : base("WebChatContext")
        {
        }

        public DbSet<Message> Messages { get; set; }

        public DbSet<User> Users { get; set; }
    }
}