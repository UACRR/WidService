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
            LicPlace = new HashSet<LicPlace>();
            License = new HashSet<License>();
            LicenseAgrParam = new HashSet<LicenseAgrParam>();
            MoneyPeriodLink = new HashSet<MoneyPeriodLink>();
            PaidPeriod = new HashSet<PaidPeriod>();
        }

        public int LicId { get; set; }
        public int LicCode { get; set; }
        public int? LicType { get; set; }
        public int? CustId { get; set; }
        public string LicNum { get; set; }
        public DateTime? LicDate { get; set; }
        public int? LicStatus { get; set; }
        public int LicClass { get; set; }
        public int AgrId { get; set; }
        public int? LicSize { get; set; }
        public int? LicVersion { get; set; }

        public AgreementMaster Agr { get; set; }
        [JsonIgnore]
        public Client Cust { get; set; }
        [JsonIgnore]
        public AgrLicenseType LicCodeNavigation { get; set; }
        [JsonIgnore]
        public AgreementStatus LicStatusNavigation { get; set; }
        [JsonIgnore]
        public LicenseType LicTypeNavigation { get; set; }
        [JsonIgnore]
        public LicenseBigR LicenseBigR { get; set; }
        [JsonIgnore]
        public ICollection<BrRegItem> BrRegItem { get; set; }
        [JsonIgnore]
        public ICollection<LicPlace> LicPlace { get; set; }
        public ICollection<License> License { get; set; }
        public ICollection<LicenseAgrParam> LicenseAgrParam { get; set; }
        [JsonIgnore]
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
    }
}









