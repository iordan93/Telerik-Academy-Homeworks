namespace AlbumsModel
{
    using System;
    using System.Collections.Generic;

    public class Artist
    {
        public Artist()
        {
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
