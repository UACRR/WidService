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

        public int custId { get; set; }
        public int CRKindCode { get; set; }
        public bool ourService { get; set; }

        public CopyrightKind CRKindCodeNavigation { get; set; }
        public RightHolder cust { get; set; }
        public ICollection<CustCmRight> CustCmRight { get; set; }
    }
}
