using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TermsOfService
    {
        public TermsOfService()
        {
            CustCmRight = new HashSet<CustCmRight>();
        }

        public int CustId { get; set; }
        public int CrkindCode { get; set; }

        public CopyrightKind CrkindCodeNavigation { get; set; }
        public RightHolder Cust { get; set; }
        public ICollection<CustCmRight> CustCmRight { get; set; }
    }
}
