using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MoneyPrepayLink : IMoneyPrepayLink
    {
        public int LinkId { get; set; }
        public int PaidId { get; set; }
        public int LicId { get; set; }
        public int LicVersion { get; set; }
        public int CustIdRh { get; set; }
        public decimal Amount { get; set; }
        public int? TurnId { get; set; }
        public int? PrepayType { get; set; }

        public virtual LicAuthorBr LicAuthorBr { get; set; }
        public virtual MoneyReceived Paid { get; set; }
        public virtual PrePayType PrepayTypeNavigation { get; set; }
    }
}

