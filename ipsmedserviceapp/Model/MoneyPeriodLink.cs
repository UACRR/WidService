using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MoneyPeriodLink
    {
        public int periodId { get; set; }
        public int paidId { get; set; }
        public int licId { get; set; }
        public DateTime modifyDate { get; set; }
        public decimal amount { get; set; }
        public int? status { get; set; }

        [JsonIgnore]
        public LicenseAgreement lic { get; set; }
        [JsonIgnore]
        public MoneyReceived paid { get; set; }
        [JsonIgnore]
        public PaidPeriod period { get; set; }
        [JsonIgnore]
        public MoneyLinkStatus statusNavigation { get; set; }
    }
}

