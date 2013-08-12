namespace AlbumsModel
{
    using System;
    using System.Collections.Generic;

    public class AlbumModel
    {
        public AlbumModel()
        {
            this.Songs = new HashSet<SongModel>();
            this.Artists = new HashSet<ArtistModel>();
        }

        public string Title { get; set; }
        
        public int? Year { get; set; }

        public int? ProducerId { get; set; }

        public virtual IEnumerable<ArtistModel> Artists { get; set; }

        public virtual Producer Producer { get; set; }

        public IEnumerable<SongModel> Songs { get; set; }
    }
}
