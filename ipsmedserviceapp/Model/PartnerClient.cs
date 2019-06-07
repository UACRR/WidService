using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PartnerClient
    {
        public int CustId { get; set; }
        public int ClCustId { get; set; }

        public virtual Client ClCust { get; set; }
        public virtual Partner Cust { get; set; }
    }
}
