using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterCount : IRegisterCount
    {
        public decimal regCntId { get; set; }
        public int? regId { get; set; }
        public int? regIItemId { get; set; }
        public int? objId { get; set; }
        public int? custId { get; set; }
        public int? cRType { get; set; }
        public int? cRKindCode { get; set; }
        public decimal? rate { get; set; }
        public decimal? rateCommiss { get; set; }
        public int? cmCustId { get; set; }
        public int? regIdBr { get; set; }
        public int? regItemIdBr { get; set; }
        public decimal? prepaySum { get; set; }

        public CopyrightKind cRKindCodeNavigation { get; set; }
        public Community cmCust { get; set; }
        public RightHolder cust { get; set; }
        public BrRegItem regI { get; set; }
    }
}

