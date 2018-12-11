using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MoneyPeriodLink : IMoneyPeriodLink
    {
        public int PeriodId { get; set; }
        public int PaidId { get; set; }
        public int LicId { get; set; }
        public DateTime ModifyDate { get; set; }
        public decimal Amount { get; set; }
        public int? Status { get; set; }

        [JsonIgnore]
        public LicenseAgreement Lic { get; set; }
        public MoneyReceived Paid { get; set; }
        [JsonIgnore]
        public PaidPeriod Period { get; set; }
        [JsonIgnore]
        public MoneyLinkStatus StatusNavigation { get; set; }
    }
}


