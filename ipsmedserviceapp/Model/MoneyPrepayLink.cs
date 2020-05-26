using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MoneyPrepayLink
    {
        public int LinkId { get; set; }
        public int PaidId { get; set; }
        public int LicId { get; set; }
        public int LicVersion { get; set; }
        public int CustIdRh { get; set; }
        public decimal Amount { get; set; }
        public int? TurnId { get; set; }

        public virtual LicAuthorBr LicAuthorBr { get; set; }
        public virtual MoneyReceived Paid { get; set; }
    }
}
