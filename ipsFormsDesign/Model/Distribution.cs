using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Distribution
    {
        public Distribution()
        {
            DistributionItem = new HashSet<DistributionItem>();
        }

        public int DistId { get; set; }
        public int? RegId { get; set; }
        public int? PeriodId { get; set; }
        public int CRkindCode { get; set; }
        public int Status { get; set; }
        public DateTime DistribDate { get; set; }
        public decimal Amount { get; set; }
        public decimal PartnerCommiss { get; set; }
        public decimal CourtFee { get; set; }
        public int? PartnerId { get; set; }
        public bool? IsCourt { get; set; }
        public int? RegIdBr { get; set; }
        public int? DistType { get; set; }
        public int? CustId { get; set; }

        public CopyrightKind CRkindCodeNavigation { get; set; }
        public Client Cust { get; set; }
        public Partner Partner { get; set; }
        public PaidPeriod Period { get; set; }
        public Register Reg { get; set; }
        public BrRegister RegIdBrNavigation { get; set; }
        public DistribStatus StatusNavigation { get; set; }
        public ICollection<DistributionItem> DistributionItem { get; set; }
    }
}
