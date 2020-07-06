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
        public int? RmId { get; set; }
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
        public int? CRightId { get; set; }

        public virtual CopyRight CRight { get; set; }
        public virtual CopyrightKind CRkindCodeNavigation { get; set; }
        public virtual Client Cust { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual Register Reg { get; set; }
        public virtual BrRegister RegIdBrNavigation { get; set; }
        public virtual RegisterRatedList Rm { get; set; }
        public virtual DistribStatus StatusNavigation { get; set; }
        public virtual ICollection<DistributionItem> DistributionItem { get; set; }
    }
}
