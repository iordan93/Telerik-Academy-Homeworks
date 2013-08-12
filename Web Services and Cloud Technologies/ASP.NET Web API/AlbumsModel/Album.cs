namespace AlbumsModel
{
    using System;
    using System.Collections.Generic;

    public class Album
    {
        public Album()
        {
            this.Artists = new HashSet<Artist>();
            this.Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        public string Title { get; set; }
        
        public int? Year { get; set; }

        public int? ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
