using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TermsOfService : ITermsOfService
    {
        public TermsOfService()
        {
            CustCmRight = new HashSet<CustCmRight>();
        }

        public int CustId { get; set; }
        public int CrkindCode { get; set; }
        public bool OurService { get; set; }

        public CopyrightKind CrkindCodeNavigation { get; set; }
        public RightHolder Cust { get; set; }
        public ICollection<CustCmRight> CustCmRight { get; set; }
    }
}

