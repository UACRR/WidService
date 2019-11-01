using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicenseAgreement : ILicenseAgreement
    {
        public LicenseAgreement()
        {
            BrRegItem = new ObservableListSource<BrRegItem>();
            Fixation = new ObservableListSource<Fixation>();
            LicPlace = new ObservableListSource<LicPlace>();
            LicenseAgrParam = new ObservableListSource<LicenseAgrParam>();
            MoneyPeriodLink = new ObservableListSource<MoneyPeriodLink>();
            PaidPeriod = new ObservableListSource<PaidPeriod>();
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

        public virtual AgreementMaster Agr { get; set; }
        [JsonIgnore]
        public virtual Client Cust { get; set; }
        [JsonIgnore]
        public virtual AgrLicenseType LicCodeNavigation { get; set; }
        [JsonIgnore]
        public virtual AgreementStatus LicStatusNavigation { get; set; }
        [JsonIgnore]
        public virtual LicenseType LicTypeNavigation { get; set; }
        public virtual LicenseBigR LicenseBigR { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<BrRegItem> BrRegItem { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<Fixation> Fixation { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<LicPlace> LicPlace { get; set; }
        public virtual ObservableListSource<LicenseAgrParam> LicenseAgrParam { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public virtual ObservableListSource<PaidPeriod> PaidPeriod { get; set; }
    }
}


