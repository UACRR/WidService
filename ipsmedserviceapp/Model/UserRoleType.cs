using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UserRoleType
    {
        public UserRoleType()
        {
            UserRole = new HashSet<UserRole>();
        }

        public int TypeCode { get; set; }
        public int IsAdmin { get; set; }
        public string TypeNameRu { get; set; }
        public string TypeNameEn { get; set; }
        public string TypeNameUk { get; set; }

        public ICollection<UserRole> UserRole { get; set; }
    }
}
