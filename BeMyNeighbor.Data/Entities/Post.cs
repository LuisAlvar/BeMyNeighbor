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
        public int UserId { get; set; }
        public DateTime DateModified { get; set; }
        public bool DoneFlag { get; set; }
        public DateTime DateSelected { get; set; }
        public int UserSelectedId { get; set; }

        public virtual Community Community { get; set; }
        public virtual GeoLocation GeoLocation { get; set; }
        public virtual Task TaskType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<UsersEvaluation> UsersEvaluation { get; set; }
    }
}
