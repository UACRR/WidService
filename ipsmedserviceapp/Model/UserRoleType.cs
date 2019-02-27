using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UserRoleType
    {
        public UserRoleType()
        {
            UserRole = new HashSet<UserRole>();
            UserRoleTypeTr = new HashSet<UserRoleTypeTr>();
        }

        public int CodeI { get; set; }
        public int IsAdmin { get; set; }
        public string TypeNameRu { get; set; }
        public string TypeNameEn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
        public virtual ICollection<UserRoleTypeTr> UserRoleTypeTr { get; set; }
    }
}
