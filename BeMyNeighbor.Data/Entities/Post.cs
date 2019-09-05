using System;
using System.Collections.Generic;

namespace BeMyNeighbor.Data.Entities
{
    public partial class Post
    {
        public Post()
        {
            UsersEvaluation = new HashSet<UsersEvaluation>();
        }

        public int PostId { get; set; }
        public int GeoLocationId { get; set; }
        public int CommunityId { get; set; }
        public DateTime DatePosted { get; set; }
        public int TaskTypeId { get; set; }

        public virtual Community Community { get; set; }
        public virtual GeoLocation GeoLocation { get; set; }
        public virtual Task TaskType { get; set; }
        public virtual ICollection<UsersEvaluation> UsersEvaluation { get; set; }
    }
}
