using System;
using System.Collections.Generic;

namespace BeMyNeighbor.Data.Entities
{
    public partial class Community
    {
        public Community()
        {
            Post = new HashSet<Post>();
        }

        public int CommunityId { get; set; }
        public string CommunityName { get; set; }
        public int LocationId { get; set; }
        public decimal Radius { get; set; }

        public virtual GeoLocation Location { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
