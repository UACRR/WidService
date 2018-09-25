using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MoneyPeriodLink : IMoneyPeriodLink
    {
        public int periodId { get; set; }
        public int paidId { get; set; }
        public int licId { get; set; }
        public DateTime modifyDate { get; set; }
        public decimal amount { get; set; }
        public int? status { get; set; }

        public LicenseAgreement lic { get; set; }
        public MoneyReceived paid { get; set; }
        public PaidPeriod period { get; set; }
        public MoneyLinkStatus statusNavigation { get; set; }
    }
}

