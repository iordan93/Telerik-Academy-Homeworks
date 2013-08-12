namespace AlbumsClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlbumsModel;

    public class AlbumsClient
    {
        public static void Main()
        {
            DataPersister persister = new DataPersister();

            // The data persister uses JSON to send and receive data. 
            // To use XML instead, uncomment the last line in the DataPersister class constructor
            // (and comment the one before it)

            #region Albums
            Album album = new Album()
            {
                Artists = new List<Artist>()
                {
                    new Artist()
                    {
                        Name = "Michael Jackson"
                    }
                },
                Year = 1997,
                Title = "Thriller",
                Producer = new Producer()
                {
                    Name = "Michael Jackson"
                },
                Songs = new List<Song>()
                {
                    new Song()
                    {
                        Title = "Song",
                        Year = 1999,
                        Genre = "Rock",
                        ArtistId = 1
                    }
                }
            };

            persister.Create<Album>("albums", album);
            Console.WriteLine(new string('-', 15));

            IEnumerable<AlbumModel> albums = persister.GetAll<AlbumModel>("albums");
            foreach (var al in albums)
            {
                Console.WriteLine("{0} | {1} | {2} | {3}", al.Title, al.Year, string.Join(", ", al.Artists.Select(a => a.Name)), al.Producer.Name);
            }

            Console.WriteLine(new string('-', 15));

            AlbumModel singleAlbum = persister.GetSingle<AlbumModel>("albums", 1);
            Console.WriteLine("{0} | {1} | {2} | {3}", singleAlbum.Title, singleAlbum.Year, string.Join(", ", singleAlbum.Artists), singleAlbum.Producer.Name);
            Console.WriteLine(new string('-', 15));

            Album newAlbum = new Album()
            {
                Id = 1,
                Title = "Dangerous",
                Year = 1997,
                ProducerId = 1
            };
            persister.Update<Album>("albums", 1, newAlbum);
            Console.WriteLine(new string('-', 15));

            persister.Delete<Album>("albums", 1);
            Console.WriteLine(new string('-', 15));
            #endregion

            Console.WriteLine(new string('*', 15));

            #region Artists
            Artist artist = new Artist()
            {
                Name = "Madonna",
                DateOfBirth = new DateTime(1958, 8, 16),
                Country = new Country()
                {
                    Name = "USA"
                }
            };

            persister.Create<Artist>("artists", artist);
            Console.WriteLine(new string('-', 15));

            IEnumerable<ArtistModel> artists = persister.GetAll<ArtistModel>("artists");
            foreach (var ar in artists)
            {
                Console.WriteLine("{0} | {1}", ar.Name, ar.DateOfBirth);
            }

            Console.WriteLine(new string('-', 15));

            ArtistModel singleArtist = persister.GetSingle<ArtistModel>("artists", 2);
            Console.WriteLine("{0} | {1} | {2}", singleArtist.Name, singleArtist.DateOfBirth, singleArtist.Country.Name);
            Console.WriteLine(new string('-', 15));

            Artist newArtist = new Artist()
            {
                Id = 2,
                Name = "John Travolta",
                DateOfBirth = new DateTime(1954, 2, 18),
                CountryId = 1
            };

            persister.Update<Artist>("artists", 2, newArtist);
            Console.WriteLine(new string('-', 15));

            persister.Delete<Artist>("artists", 2);
            Console.WriteLine(new string('-', 15));
            #endregion

            Console.WriteLine(new string('*', 15));

            #region Producers
            Producer producer = new Producer()
            {
                Name = "Daniel Lanois"
            };

            persister.Create<Producer>("producers", producer);
            Console.WriteLine(new string('-', 15));

            IEnumerable<Producer> producers = persister.GetAll<Producer>("producers");
            foreach (var pr in producers)
            {
                Console.WriteLine(pr.Name);
            }

            Console.WriteLine(new string('-', 15));

            Producer singleProducer = persister.GetSingle<Producer>("producers", 2);
            Console.WriteLine(singleProducer.Name);
            Console.WriteLine(new string('-', 15));

            Producer newProducer = new Producer()
            {
                Id = 2,
                Name = "Dr. Dre"
            };
            persister.Update<Producer>("producers", 2, newProducer);
            Console.WriteLine(new string('-', 15));

            persister.Delete<Producer>("producers", 2);
            Console.WriteLine(new string('-', 15));
            #endregion

            Console.WriteLine(new string('*', 15));

            #region Songs
            Song song = new Song()
            {
                Title = "Beat It",
                Year = 1982,
                Genre = "Hard Rock",
                Artist = new Artist()
                {
                    Name = "Michael Jackson"
                },
                Albums = new List<Album> 
                {
                    album
                }
            };

            persister.Create<Song>("songs", song);
            Console.WriteLine(new string('-', 15));

            IEnumerable<SongModel> songs = persister.GetAll<SongModel>("songs");
            foreach (var s in songs)
            {
                Console.WriteLine("{0} | {1} | {2}", s.Title, s.Year, s.Artist.Name);
            }

            Console.WriteLine(new string('-', 15));

            SongModel singleSong = persister.GetSingle<SongModel>("songs", 2);
            Console.WriteLine("{0} | {1} | {2}", singleSong.Title, singleSong.Year, singleSong.Artist.Name);
            Console.WriteLine(new string('-', 15));

            Song newSong = new Song()
            {
                Id = 2,
                ArtistId = 1,
                Year = 1995,
                Title = "Earth Song",
                Genre = "Blues"
            };
            persister.Update<Song>("songs", 2, newSong);
            Console.WriteLine(new string('-', 15));

            persister.Delete<Song>("songs", 2);
            Console.WriteLine(new string('-', 15));
            #endregion
        }
    }
}