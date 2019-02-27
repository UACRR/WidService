using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PartnerClient : IPartnerClient
    {
        public int CustId { get; set; }
        public int ClCustId { get; set; }

        public virtual Client ClCust { get; set; }
        public virtual Partner Cust { get; set; }
    }
}

