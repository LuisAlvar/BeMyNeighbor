using System;
using System.Collections.Generic;

namespace BeMyNeighbor.Data.Entities
{
    public partial class User
    {
        public User()
        {
            Post = new HashSet<Post>();
            UsersEvaluation = new HashSet<UsersEvaluation>();
        }

        public int UserId { get; set; }
        public int CommunityId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string SeedPassword { get; set; }
        public bool VerifiedUser { get; set; }
        public int NubmerOfPoints { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<UsersEvaluation> UsersEvaluation { get; set; }
    }
}
