using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterCount
    {
        public decimal RegCntId { get; set; }
        public int? RegId { get; set; }
        public int? RegIitemId { get; set; }
        public int? ObjId { get; set; }
        public int? CustId { get; set; }
        public int? CRtype { get; set; }
        public int? CRkindCode { get; set; }
        public decimal? Rate { get; set; }
        public decimal? RateCommiss { get; set; }
        public int? CmCustId { get; set; }
        public int? RegIdBr { get; set; }
        public int? RegItemIdBr { get; set; }
        public decimal? PrepaySum { get; set; }
        public int? DistItemId { get; set; }
        public int? DistId { get; set; }

        public virtual CopyrightKind CRkindCodeNavigation { get; set; }
        public virtual Community CmCust { get; set; }
        public virtual RightHolder Cust { get; set; }
        public virtual DistributionItem DistI { get; set; }
        public virtual RegisterItem RegI { get; set; }
        public virtual BrRegItem RegINavigation { get; set; }
    }
}
