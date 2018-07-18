using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MoneyPrepayLink
    {
        public int PaidId { get; set; }
        public int CRightId { get; set; }
        public decimal? Amount { get; set; }

        public LicAuthorBr CRight { get; set; }
        public MoneyReceived Paid { get; set; }
    }
}
