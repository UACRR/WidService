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
        public bool OurService { get; set; }

        public virtual CopyrightKind CrkindCodeNavigation { get; set; }
        public virtual RightHolder Cust { get; set; }
        public virtual ICollection<CustCmRight> CustCmRight { get; set; }
    }
}
