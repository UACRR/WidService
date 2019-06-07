using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TerritoryExclude
    {
        public int CustId { get; set; }
        public string CountryCode { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual RightHolder Cust { get; set; }
    }
}
