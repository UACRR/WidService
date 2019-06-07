using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MoneyPrepayLink : IMoneyPrepayLink
    {
        public int PaidId { get; set; }
        public int CRightId { get; set; }
        public decimal? Amount { get; set; }

        public virtual MoneyReceived Paid { get; set; }
    }
}

