using System;
using System.Collections.Generic;

namespace BeMyNeighbor.Data.Entities
{
    public partial class Task
    {
        public Task()
        {
            Post = new HashSet<Post>();
            UsersEvaluation = new HashSet<UsersEvaluation>();
        }

        public int TaskTypeId { get; set; }
        public string TaskDescription { get; set; }
        public int TaskTypeRewardPoints { get; set; }

        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<UsersEvaluation> UsersEvaluation { get; set; }
    }
}
