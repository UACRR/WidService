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
        public DateTime? DateActPrint { get; set; }

        [JsonIgnore]
        public virtual Client Cust { get; set; }
        [JsonIgnore]
        public virtual LicenseAgreement Lic { get; set; }
        [JsonIgnore]
        public virtual Period PeriodTypeNavigation { get; set; }
        [JsonIgnore]
        public virtual PeriodStatus StatusNavigation { get; set; }
        public virtual ICollection<BrRegister> BrRegister { get; set; }
        public virtual ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public virtual ICollection<RegisterRatedList> RegisterRatedList { get; set; }
    }
}




