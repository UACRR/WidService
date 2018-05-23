using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AspNetRoleClaims : IAspNetRoleClaims
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string RoleId { get; set; }

        public AspNetRoles Role { get; set; }
    }
}

