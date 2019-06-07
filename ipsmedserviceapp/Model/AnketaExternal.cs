using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaExternal
    {
        public int CustId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string InnOkpo { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Customer Cust { get; set; }
    }
}
