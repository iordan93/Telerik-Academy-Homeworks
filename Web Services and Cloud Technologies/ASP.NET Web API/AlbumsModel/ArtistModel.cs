namespace AlbumsModel
{
    using System;

    public class ArtistModel
    {
        public string Name { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
