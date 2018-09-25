using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ExternalPay : IExternalPay
    {
        public int paidId { get; set; }
        public DateTime? inputDate { get; set; }
        public string mfo { get; set; }
        public string okpol { get; set; }
        public string account { get; set; }
        public string r030 { get; set; }
        public string codeOper { get; set; }
        public string mfoCorr { get; set; }
        public string nameMfoCorr { get; set; }
        public string accountCorr { get; set; }
        public string okpoCorr { get; set; }
        public string nameCorr { get; set; }
        public string docNum { get; set; }
        public DateTime? docDate { get; set; }
        public decimal? sDebet { get; set; }
        public decimal? sCredit { get; set; }
        public string nplat { get; set; }
        public decimal? sNcCur { get; set; }
        public int? status { get; set; }
        public DateTime? dateOper { get; set; }
    }
}

