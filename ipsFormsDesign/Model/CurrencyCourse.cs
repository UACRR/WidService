using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CurrencyCourse : ICurrencyCourse
    {
        public string R030 { get; set; }
        public DateTime CDate { get; set; }
        public int? CUnit { get; set; }
        public decimal? CAmount { get; set; }
        public decimal? CAmountNbu { get; set; }

        public virtual KlR030 R030Navigation { get; set; }
    }
}

