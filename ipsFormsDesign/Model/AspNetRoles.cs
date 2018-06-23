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

        public string Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public ObservableListSource<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public ObservableListSource<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}

