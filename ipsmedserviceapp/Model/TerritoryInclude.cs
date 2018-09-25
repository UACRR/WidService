using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TerritoryInclude
    {
        public int custId { get; set; }
        public string countryCode { get; set; }

        public Country countryCodeNavigation { get; set; }
        public RightHolder cust { get; set; }
    }
}
