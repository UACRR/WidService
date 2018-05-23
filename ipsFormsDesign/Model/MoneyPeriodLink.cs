using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MoneyPeriodLink : IMoneyPeriodLink
    {
        public int PeriodId { get; set; }
        public int PaidId { get; set; }
        public int LicId { get; set; }
        public DateTime ModifyDate { get; set; }
        public decimal Amount { get; set; }
        public int? Status { get; set; }

        public LicenseAgreement Lic { get; set; }
        public MoneyReceived Paid { get; set; }
        public PaidPeriod Period { get; set; }
        public MoneyLinkStatus StatusNavigation { get; set; }
    }
}

