using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PartnerClient
    {
        public int custId { get; set; }
        public int clCustId { get; set; }

        public Client clCust { get; set; }
        public Partner cust { get; set; }
    }
}
