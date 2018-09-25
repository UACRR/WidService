using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicenseAgreement
    {
        public LicenseAgreement()
        {
            BrRegItem = new HashSet<BrRegItem>();
            Fixation = new HashSet<Fixation>();
            LicenseAgrParam = new HashSet<LicenseAgrParam>();
            MoneyPeriodLink = new HashSet<MoneyPeriodLink>();
            PaidPeriod = new HashSet<PaidPeriod>();
            licPlace = new HashSet<licPlace>();
        }

        public int licId { get; set; }
        public int licCode { get; set; }
        public int? licType { get; set; }
        public int? custId { get; set; }
        public int? licStatus { get; set; }
        public int licClass { get; set; }
        public int agrId { get; set; }
        public int? licSize { get; set; }
        public int? licVersion { get; set; }
        public int? prolongVersion { get; set; }

        [JsonIgnore]
        public AgreementMaster agr { get; set; }
        [JsonIgnore]
        public Client cust { get; set; }
        [JsonIgnore]
        public AgrLicenseType licCodeNavigation { get; set; }
        [JsonIgnore]
        public AgreementStatus licStatusNavigation { get; set; }
        [JsonIgnore]
        public LicenseType licTypeNavigation { get; set; }
        public LicenseBigR LicenseBigR { get; set; }
        [JsonIgnore]
        public ICollection<BrRegItem> BrRegItem { get; set; }
        [JsonIgnore]
        public ICollection<Fixation> Fixation { get; set; }
        public ICollection<LicenseAgrParam> LicenseAgrParam { get; set; }
        [JsonIgnore]
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
        [JsonIgnore]
        public ICollection<licPlace> licPlace { get; set; }
    }
}

