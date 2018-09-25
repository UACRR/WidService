using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AspNetUserRoles
    {
        public string userId { get; set; }
        public string roleId { get; set; }

        public AspNetRoles role { get; set; }
        public AspNetUsers user { get; set; }
    }
}
