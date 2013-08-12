namespace AlbumsModel
{
    using System;
    using System.Linq;

    public static class ModelConverter
    {
        public static AlbumModel ConvertAlbum(Album album)
        {
            AlbumModel albumModel = new AlbumModel()
            {
                Producer = album.Producer,
                ProducerId = album.ProducerId,
                Artists = from artist in album.Artists
                          select new ArtistModel()
                          {
                              Name = artist.Name,
                              DateOfBirth = artist.DateOfBirth,
                              CountryId = artist.CountryId,
                              Country = artist.Country
                          },
                Title = album.Title,
                Year = album.Year,
                Songs = from song in album.Songs
                        select new SongModel()
                        {
                            ArtistId = song.ArtistId,
                            Artist = new ArtistModel()
                            {
                                Name = song.Artist.Name,
                                CountryId = song.Artist.CountryId,
                                Country = song.Artist.Country,
                                DateOfBirth = song.Artist.DateOfBirth
                            },
                            Genre = song.Genre,
                            Title = song.Title,
                            Year = song.Year
                        }
            };

            return albumModel;
        }

        public static ArtistModel ConvertArtist(Artist artist)
        {
            ArtistModel artistModel = new ArtistModel()
            {
                Name = artist.Name,
                CountryId = artist.CountryId,
                Country = artist.Country,
                DateOfBirth = artist.DateOfBirth
            };

            return artistModel;
        }

        public static SongModel ConvertSong(Song song)
        {
            SongModel songModel = new SongModel()
            {
                ArtistId = song.ArtistId,
                Artist = new ArtistModel()
                {
                    Name = song.Artist.Name,
                    CountryId = song.Artist.CountryId,
                    Country = song.Artist.Country,
                    DateOfBirth = song.Artist.DateOfBirth
                },
                Genre = song.Genre,
                Title = song.Title,
                Year = song.Year
            };

            return songModel;
        }
    }
}