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
            Invoice = new HashSet<Invoice>();
            LicPlace = new HashSet<LicPlace>();
            LicenseAgrParam = new HashSet<LicenseAgrParam>();
            MoneyPeriodLink = new HashSet<MoneyPeriodLink>();
            PaidPeriod = new HashSet<PaidPeriod>();
        }

        public int LicId { get; set; }
        public int LicCode { get; set; }
        public int? LicType { get; set; }
        public int? CustId { get; set; }
        public int? LicStatus { get; set; }
        public int LicClass { get; set; }
        public int AgrId { get; set; }
        public int? LicSize { get; set; }
        public int? LicVersion { get; set; }
        public int? ProlongVersion { get; set; }
        public int? LicMethod { get; set; }

        public virtual AgreementMaster Agr { get; set; }
        [JsonIgnore]
        public virtual Client Cust { get; set; }
        [JsonIgnore]
        public virtual AgrLicenseType LicCodeNavigation { get; set; }
        [JsonIgnore]
        public virtual LicenseMethodType LicMethodNavigation { get; set; }
        [JsonIgnore]
        public virtual AgreementStatus LicStatusNavigation { get; set; }
        [JsonIgnore]
        public virtual LicenseType LicTypeNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrRegItem> BrRegItem { get; set; }
        [JsonIgnore]
        public virtual ICollection<Fixation> Fixation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Invoice> Invoice { get; set; }
        [JsonIgnore]
        public virtual ICollection<LicPlace> LicPlace { get; set; }
        public virtual ICollection<LicenseAgrParam> LicenseAgrParam { get; set; }
        [JsonIgnore]
        public virtual ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public virtual ICollection<PaidPeriod> PaidPeriod { get; set; }
    }
}



