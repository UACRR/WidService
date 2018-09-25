using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Invoice
    {
        public int docId { get; set; }
        public int? payCustId { get; set; }
        public int? recCustId { get; set; }
        public int? payAnk { get; set; }
        public int? recAnk { get; set; }
        public string r030 { get; set; }
        public decimal? Amount { get; set; }
        public string recMFO { get; set; }
        public string recBankName { get; set; }
        public string purpose { get; set; }
        public int? status { get; set; }
    }
}
