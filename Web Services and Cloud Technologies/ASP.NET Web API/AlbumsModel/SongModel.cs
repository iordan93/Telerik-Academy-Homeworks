namespace AlbumsModel
{
    using System;

    public class SongModel
    {
        public string Title { get; set; }

        public int? Year { get; set; }

        public string Genre { get; set; }

        public int ArtistId { get; set; }

        public virtual ArtistModel Artist { get; set; }
    }
}
