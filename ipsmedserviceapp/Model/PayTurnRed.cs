using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PayTurnRed
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
        public DateTime? DateCreate { get; set; }
    }
}
