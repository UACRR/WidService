using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AspNetUserLogins
    {
        public string loginProvider { get; set; }
        public string providerKey { get; set; }
        public string providerDisplayName { get; set; }
        public string userId { get; set; }

        public AspNetUsers user { get; set; }
    }
}
