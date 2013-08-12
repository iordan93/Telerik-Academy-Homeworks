namespace AlbumsServices
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Web.Http.Dependencies;
    using AlbumsData;
    using AlbumsModel;
    using AlbumsServices.Controllers;
    using AlbumsRepositories;

    public class EfDependencyResolver : IDependencyResolver
    {
        private static DbContext context = new AlbumsContext();

        private static readonly IRepository<Album> albumsRepository = new EfRepository<Album>(context);
        private static readonly IRepository<Artist> artistsRepository = new EfRepository<Artist>(context);
        private static readonly IRepository<Producer> producersRepository = new EfRepository<Producer>(context);
        private static readonly IRepository<Song> songsRepository = new EfRepository<Song>(context);
        private static readonly IRepository<Country> countriesRepository = new EfRepository<Country>(context);

        private static readonly ModelBuilder modelBuilder = new ModelBuilder(
            albumsRepository,
            artistsRepository,
            producersRepository,
            songsRepository,
            countriesRepository);

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(AlbumsController))
            {
                return new AlbumsController(albumsRepository, modelBuilder);
            }
            else if (serviceType == typeof(ArtistsController))
            {
                return new ArtistsController(artistsRepository, modelBuilder);
            }
            else if (serviceType == typeof(ProducersController))
            {
                return new ProducersController(producersRepository, modelBuilder);
            }
            else if (serviceType == typeof(SongsController))
            {
                return new SongsController(songsRepository, modelBuilder);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}