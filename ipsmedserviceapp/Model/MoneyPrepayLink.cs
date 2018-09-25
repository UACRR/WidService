using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MoneyPrepayLink
    {
        public int paidId { get; set; }
        public int cRightId { get; set; }
        public decimal? amount { get; set; }

        public MoneyReceived paid { get; set; }
    }
}
