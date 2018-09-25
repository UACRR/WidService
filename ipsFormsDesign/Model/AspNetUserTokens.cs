using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AspNetUserTokens : IAspNetUserTokens
    {
        public string userId { get; set; }
        public string loginProvider { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
}

