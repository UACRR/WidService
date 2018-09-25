using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaims>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        public string id { get; set; }
        public string concurrencyStamp { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string normalizedName { get; set; }

        public ICollection<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
