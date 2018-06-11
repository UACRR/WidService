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
            Distribution = new HashSet<Distribution>();
            MoneyPeriodLink = new HashSet<MoneyPeriodLink>();
            Register = new HashSet<Register>();
        }

        public int PeriodId { get; set; }
        public int CustId { get; set; }
        public int PeriodType { get; set; }
        public int LicId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public decimal Undistribamount { get; set; }
        public decimal Distribamount { get; set; }
        public string PeriodName { get; set; }
        public bool? FagFirst { get; set; }

        [JsonIgnore]
        public Client Cust { get; set; }
        [JsonIgnore]
        public LicenseAgreement Lic { get; set; }
        [JsonIgnore]
        public Period PeriodTypeNavigation { get; set; }
        [JsonIgnore]
        public PeriodStatus StatusNavigation { get; set; }
        public ICollection<BrRegister> BrRegister { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public ICollection<Register> Register { get; set; }
    }
}











