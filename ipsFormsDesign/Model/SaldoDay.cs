using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SaldoDay : ISaldoDay
    {
        public int accId { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
        public string r030 { get; set; }
        public decimal? rest { get; set; }
        public decimal? restCourt { get; set; }
        public decimal? deboborot { get; set; }
        public decimal? krdOborot { get; set; }
        public decimal? deboborotCourt { get; set; }
        public decimal? krdOborotCourt { get; set; }
        public decimal? restBegin { get; set; }
        public decimal? restBeginCourt { get; set; }
    }
}

