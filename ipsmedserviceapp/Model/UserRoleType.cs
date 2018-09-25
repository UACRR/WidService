using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UserRoleType
    {
        public UserRoleType()
        {
            UserRoleTypeTr = new HashSet<UserRoleTypeTr>();
            userRole = new HashSet<userRole>();
        }

        public int codeI { get; set; }
        public int isAdmin { get; set; }
        public string typeNameRu { get; set; }
        public string typeNameEn { get; set; }
        public string name { get; set; }

        public ICollection<UserRoleTypeTr> UserRoleTypeTr { get; set; }
        public ICollection<userRole> userRole { get; set; }
    }
}
