using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PartnerClient : IPartnerClient
    {
        public int custId { get; set; }
        public int clCustId { get; set; }

        public Client clCust { get; set; }
        public Partner cust { get; set; }
    }
}

