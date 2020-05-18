using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PayTurnCm : IPayTurnCm
    {
        public int Id { get; set; }
        public int AccId { get; set; }
        public int? CategoryCode { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateWork { get; set; }
        public int KindCode { get; set; }
        public decimal? AmountSum { get; set; }
        public decimal? AmountCourtSum { get; set; }
        public decimal? RateCommiss { get; set; }
        public decimal? RateCourt { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountCourt { get; set; }
        public decimal? AmountCommiss { get; set; }
        public int? CustIdRh { get; set; }
        public int? CustIdCm { get; set; }
        public string AccNls { get; set; }
    }
}

