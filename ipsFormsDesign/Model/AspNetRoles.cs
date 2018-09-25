using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AspNetRoles : IAspNetRoles
    {
        public AspNetRoles()
        {
            AspNetRoleClaims = new ObservableListSource<AspNetRoleClaims>();
            AspNetUserRoles = new ObservableListSource<AspNetUserRoles>();
        }

        public string id { get; set; }
        public string concurrencyStamp { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string normalizedName { get; set; }

        public ObservableListSource<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public ObservableListSource<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}

