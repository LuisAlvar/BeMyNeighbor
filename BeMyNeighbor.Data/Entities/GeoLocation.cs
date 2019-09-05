using System;
using System.Collections.Generic;

namespace BeMyNeighbor.Data.Entities
{
    public partial class GeoLocation
    {
        public GeoLocation()
        {
            Community = new HashSet<Community>();
            Post = new HashSet<Post>();
        }

        public int GeoLocationId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual ICollection<Community> Community { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
