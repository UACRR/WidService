using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MoneyPeriodLink
    {
        public int PeriodId { get; set; }
        public int PaidId { get; set; }
        public int LicId { get; set; }
        public DateTime ModifyDate { get; set; }
        public decimal Amount { get; set; }
        public int? Status { get; set; }

        public virtual LicenseAgreement Lic { get; set; }
        public virtual MoneyReceived Paid { get; set; }
        public virtual PaidPeriod Period { get; set; }
        public virtual MoneyLinkStatus StatusNavigation { get; set; }
    }
}
