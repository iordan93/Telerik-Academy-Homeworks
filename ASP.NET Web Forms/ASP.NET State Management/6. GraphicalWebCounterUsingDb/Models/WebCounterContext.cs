namespace _6.GraphicalWebCounterUsingDb.Models
{
    using System;
    using System.Data.Entity;

    public class WebCounterContext : DbContext
    {
        public WebCounterContext()
            : base("WebCounterDb")
        {
        }

        public DbSet<WebCounter> WebCounters { get; set; }
    }
}