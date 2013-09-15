//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1._3.World
{
    using System;
    using System.Collections.Generic;
    
    public partial class Country
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
        }
    
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double SurfaceArea { get; set; }
        public Nullable<int> ContinentId { get; set; }
        public int Population { get; set; }
        public byte[] FlagImage { get; set; }
        public string Language { get; set; }
    
        public virtual ICollection<City> Cities { get; set; }
        public virtual Continent Continent { get; set; }
    }
}
