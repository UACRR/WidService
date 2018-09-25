using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CurrencyCourse : ICurrencyCourse
    {
        public string r030 { get; set; }
        public DateTime cDate { get; set; }
        public int? cUnit { get; set; }
        public decimal? cAmount { get; set; }
        public decimal? cAmountNBU { get; set; }

        public KL_R030 r030Navigation { get; set; }
    }
}

