using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AspNetRoleClaims : IAspNetRoleClaims
    {
        public int id { get; set; }
        public string claimType { get; set; }
        public string claimValue { get; set; }
        public string roleId { get; set; }

        public AspNetRoles role { get; set; }
    }
}

