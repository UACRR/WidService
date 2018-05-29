using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class UserRoleType : IUserRoleType
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

        public ICollection<UserRole> UserRole { get; set; }
        public ICollection<UserRoleTypeTr> UserRoleTypeTr { get; set; }
    }
}

