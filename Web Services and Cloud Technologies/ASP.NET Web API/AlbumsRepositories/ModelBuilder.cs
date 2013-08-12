namespace AlbumsRepositories
{
    using System;
    using System.Linq;
    using AlbumsModel;

    public class ModelBuilder
    {
        private readonly IRepository<Album> albumsRepository;
        private readonly IRepository<Artist> artistsRepository;
        private readonly IRepository<Producer> producersRepository;
        private readonly IRepository<Song> songsRepository;
        private readonly IRepository<Country> countriesRepository;

        public ModelBuilder(
            IRepository<Album> albumsRepository,
            IRepository<Artist> artistsRepository,
            IRepository<Producer> producersRepository,
            IRepository<Song> songsRepository,
            IRepository<Country> countriesRepository)
        {
            this.albumsRepository = albumsRepository;
            this.artistsRepository = artistsRepository;
            this.producersRepository = producersRepository;
            this.songsRepository = songsRepository;
            this.countriesRepository = countriesRepository;
        }

        public Album BuildAlbum(Album newAlbum, bool add = false)
        {
            Album repositoryAlbum = this.albumsRepository.GetAll()
                                        .FirstOrDefault(a => a.Title == newAlbum.Title &&
                                                             a.Year == newAlbum.Year);
            if (repositoryAlbum != null && add)
            {
                return repositoryAlbum;
            }
            else
            {
                Album album = new Album();
                if (newAlbum.Artists != null)
                {
                    foreach (var artist in newAlbum.Artists)
                    {
                        album.Artists.Add(artist);
                    }
                }

                if (newAlbum.Songs != null)
                {
                    foreach (var song in newAlbum.Songs)
                    {
                        if (song.Artist != null)
                        {
                            song.Artist = this.BuildArtist(song.Artist);
                        }

                        album.Songs.Add(song);
                    }
                }

                album.ProducerId = newAlbum.ProducerId;
                if (newAlbum.Producer != null)
                {
                    album.Producer = this.BuildProducer(newAlbum.Producer);
                }

                album.Title = newAlbum.Title;
                album.Year = newAlbum.Year;

                return album;
            }
        }

        public Artist BuildArtist(Artist newArtist, bool add = false)
        {
            Artist repositoryArtist = this.artistsRepository.GetAll().FirstOrDefault(a => a.Name == newArtist.Name);
            if (repositoryArtist != null && add)
            {
                return repositoryArtist;
            }
            else
            {
                Artist artist = new Artist();
                if (newArtist.Albums != null)
                {
                    foreach (var album in newArtist.Albums)
                    {
                        artist.Albums.Add(album);
                    }
                }

                artist.CountryId = newArtist.CountryId;
                if (newArtist.Country != null)
                {
                    artist.Country = this.BuildCountry(newArtist.Country);
                }

                artist.Name = newArtist.Name;
                artist.DateOfBirth = newArtist.DateOfBirth;

                return artist;
            }
        }

        public Producer BuildProducer(Producer newProducer, bool add = false)
        {
            Producer repositoryProducer = this.producersRepository.GetAll().FirstOrDefault(p => p.Name == newProducer.Name);
            if (repositoryProducer != null)
            {
                return repositoryProducer;
            }
            else
            {
                this.producersRepository.Create(newProducer);
                return newProducer;
            }
        }

        public Song BuildSong(Song newSong, bool add = false)
        {
            Song repositorySong = this.songsRepository.GetAll()
                                      .FirstOrDefault(s => s.Title == newSong.Title &&
                                                           s.Year == newSong.Year &&
                                                           s.Genre == newSong.Genre);

            if (repositorySong != null && add)
            {
                return repositorySong;
            }
            else
            {
                Song song = new Song();
                if (newSong.Albums != null)
                {
                    foreach (var album in newSong.Albums)
                    {
                        song.Albums.Add(album);
                    }
                }

                song.ArtistId = newSong.ArtistId;
                if (newSong.Artist != null)
                {
                    song.Artist = this.BuildArtist(newSong.Artist);
                }

                song.Genre = newSong.Genre;
                song.Title = newSong.Title;
                song.Year = newSong.Year;

                return song;
            }
        }

        public Country BuildCountry(Country newCountry)
        {
            Country repositoryCountry = this.countriesRepository.GetAll().FirstOrDefault(c => c.Name == newCountry.Name);
            if (repositoryCountry != null)
            {
                return repositoryCountry;
            }
            else
            {
                this.countriesRepository.Create(newCountry);

                return newCountry;
            }
        }
    }
}