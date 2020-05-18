using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterCcid : IRegisterCcid
    {
        public int RegId { get; set; }
        public int DdexReportId { get; set; }
        public int CcidClFileId { get; set; }
        public decimal? AmountCur { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string R030 { get; set; }
        public decimal? AmountCurR { get; set; }

        public virtual KlR030 R030Navigation { get; set; }
        public virtual Register Reg { get; set; }
    }
}

