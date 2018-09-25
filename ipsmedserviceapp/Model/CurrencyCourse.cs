using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CurrencyCourse
    {
        public string R030 { get; set; }
        public DateTime CDate { get; set; }
        public int? CUnit { get; set; }
        public decimal? CAmount { get; set; }
        public decimal? CAmountNbu { get; set; }

        public KlR030 R030Navigation { get; set; }
    }
}
