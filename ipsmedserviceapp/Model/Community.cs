using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Community
    {
        public Community()
        {
            AgreementAddCommunity = new HashSet<AgreementAddCommunity>();
            CustCmRight = new HashSet<CustCmRight>();
            RegisterCount = new HashSet<RegisterCount>();
        }

        public int CustId { get; set; }
        public string InterCode { get; set; }
        public string InnerCode { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ICollection<AgreementAddCommunity> AgreementAddCommunity { get; set; }
        public virtual ICollection<CustCmRight> CustCmRight { get; set; }
        public virtual ICollection<RegisterCount> RegisterCount { get; set; }
    }
}
