using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SaldoDay : ISaldoDay
    {
        public int AccId { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public string R030 { get; set; }
        public decimal? Rest { get; set; }
        public decimal? RestCourt { get; set; }
        public decimal? Deboborot { get; set; }
        public decimal? KrdOborot { get; set; }
        public decimal? DeboborotCourt { get; set; }
        public decimal? KrdOborotCourt { get; set; }
        public decimal? RestBegin { get; set; }
        public decimal? RestBeginCourt { get; set; }
    }
}

