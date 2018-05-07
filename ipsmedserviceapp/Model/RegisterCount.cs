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

        public CopyrightKind CRkindCodeNavigation { get; set; }
        public Community CmCust { get; set; }
        public RightHolder Cust { get; set; }
        public RegisterItem RegI { get; set; }
    }
}
