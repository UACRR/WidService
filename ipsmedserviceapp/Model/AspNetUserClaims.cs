using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AspNetUserClaims
    {
        public int id { get; set; }
        public string claimType { get; set; }
        public string claimValue { get; set; }
        public string userId { get; set; }

        public AspNetUsers user { get; set; }
    }
}
