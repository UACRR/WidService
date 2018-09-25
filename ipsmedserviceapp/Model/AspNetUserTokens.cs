using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AspNetUserTokens
    {
        public string userId { get; set; }
        public string loginProvider { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
}
