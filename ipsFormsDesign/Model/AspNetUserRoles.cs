using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AspNetUserRoles : IAspNetUserRoles
    {
        public string userId { get; set; }
        public string roleId { get; set; }

        public AspNetRoles role { get; set; }
        public AspNetUsers user { get; set; }
    }
}

