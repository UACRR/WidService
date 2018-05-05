using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ExternalPay
    {
        public int PaidId { get; set; }
        public DateTime? InputDate { get; set; }
        public string Mfo { get; set; }
        public string Okpol { get; set; }
        public string Account { get; set; }
        public string R030 { get; set; }
        public string CodeOper { get; set; }
        public string MfoCorr { get; set; }
        public string NameMfoCorr { get; set; }
        public string AccountCorr { get; set; }
        public string OkpoCorr { get; set; }
        public string NameCorr { get; set; }
        public string DocNum { get; set; }
        public DateTime? DocDate { get; set; }
        public decimal? SDebet { get; set; }
        public decimal? SCredit { get; set; }
        public string Nplat { get; set; }
        public decimal? SNcCur { get; set; }
        public int? Status { get; set; }
        public DateTime? DateOper { get; set; }
    }
}
