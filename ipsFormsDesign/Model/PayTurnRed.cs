using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PayTurnRed : IPayTurnRed
    {
        public int RedId { get; set; }
        public DateTime DateWork { get; set; }
        public int TurnId { get; set; }
        public int? TurnIdRed { get; set; }
        public DateTime? DateWorkRed { get; set; }
        public decimal Amount { get; set; }
        public decimal? AmountRest { get; set; }
        public int? AccId { get; set; }
        public int? RedType { get; set; }
    }
}

