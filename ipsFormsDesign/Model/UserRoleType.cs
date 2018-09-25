using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class UserRoleType : IUserRoleType
    {
        public UserRoleType()
        {
            UserRole = new ObservableListSource<UserRole>();
            UserRoleTypeTr = new ObservableListSource<UserRoleTypeTr>();
        }

        public int CodeI { get; set; }
        public int IsAdmin { get; set; }
        public string TypeNameRu { get; set; }
        public string TypeNameEn { get; set; }
        public string Name { get; set; }

        public ObservableListSource<UserRole> UserRole { get; set; }
        public ObservableListSource<UserRoleTypeTr> UserRoleTypeTr { get; set; }
    }
}

