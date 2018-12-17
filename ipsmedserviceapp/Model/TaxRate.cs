using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TaxRate
    {
        public int CodeI { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Name { get; set; }
        public decimal? Rate { get; set; }
    }
}
