using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SaldoDay
    {
        public int AccId { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public string R030 { get; set; }
        public decimal? Rest { get; set; }
        public decimal? RestCur { get; set; }
        public decimal? Deboborot { get; set; }
        public decimal? KrdOborot { get; set; }
        public decimal? DeboborotCur { get; set; }
        public decimal? KrdOborotCur { get; set; }
        public decimal? RestBegin { get; set; }
        public decimal? RestBeginCur { get; set; }
    }
}
