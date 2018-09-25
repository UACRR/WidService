using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MoneyPrepayLink : IMoneyPrepayLink
    {
        public int paidId { get; set; }
        public int cRightId { get; set; }
        public decimal? amount { get; set; }

        public MoneyReceived paid { get; set; }
    }
}

