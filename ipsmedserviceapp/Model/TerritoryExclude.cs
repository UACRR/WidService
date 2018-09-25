using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TerritoryExclude
    {
        public int CustId { get; set; }
        public string CountryCode { get; set; }

        public Country CountryCodeNavigation { get; set; }
        public RightHolder Cust { get; set; }
    }
}
