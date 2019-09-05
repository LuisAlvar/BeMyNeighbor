using System;
using System.Collections.Generic;

namespace BeMyNeighbor.Data.Entities
{
    public partial class Address
    {
        public Address()
        {
            User = new HashSet<User>();
        }

        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public int Zipcode { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
