using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class UserRoleType : IUserRoleType
    {
        public UserRoleType()
        {
            UserRoleTypeTr = new ObservableListSource<UserRoleTypeTr>();
            userRole = new ObservableListSource<userRole>();
        }

        public int codeI { get; set; }
        public int isAdmin { get; set; }
        public string typeNameRu { get; set; }
        public string typeNameEn { get; set; }
        public string name { get; set; }

        public ObservableListSource<UserRoleTypeTr> UserRoleTypeTr { get; set; }
        public ObservableListSource<userRole> userRole { get; set; }
    }
}

