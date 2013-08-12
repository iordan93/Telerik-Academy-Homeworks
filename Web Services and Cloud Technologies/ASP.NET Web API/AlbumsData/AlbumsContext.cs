namespace AlbumsData
{
    using System;
    using System.Data.Entity;
    using AlbumsModel;

    public class AlbumsContext : DbContext
    {
        public AlbumsContext()
            : base("AlbumsContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}
