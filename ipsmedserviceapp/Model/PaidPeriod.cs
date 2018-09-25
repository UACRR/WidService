using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PaidPeriod
    {
        public PaidPeriod()
        {
            BrRegister = new HashSet<BrRegister>();
            MoneyPeriodLink = new HashSet<MoneyPeriodLink>();
            RegisterRatedList = new HashSet<RegisterRatedList>();
        }

        public int periodId { get; set; }
        public int custId { get; set; }
        public int periodType { get; set; }
        public int licId { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public int status { get; set; }
        public decimal amount { get; set; }
        public decimal undistribamount { get; set; }
        public decimal distribamount { get; set; }
        public string periodName { get; set; }
        public bool? fagFirst { get; set; }
        public DateTime? dateActPrint { get; set; }

        [JsonIgnore]
        public Client cust { get; set; }
        [JsonIgnore]
        public LicenseAgreement lic { get; set; }
        [JsonIgnore]
        public Period periodTypeNavigation { get; set; }
        [JsonIgnore]
        public PeriodStatus statusNavigation { get; set; }
        public ICollection<BrRegister> BrRegister { get; set; }
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public ICollection<RegisterRatedList> RegisterRatedList { get; set; }
    }
}

