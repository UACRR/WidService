using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicenseAgreement : ILicenseAgreement
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
        public Client Cust { get; set; }
        public AgrLicenseType LicCodeNavigation { get; set; }
        public AgreementStatus LicStatusNavigation { get; set; }
        public LicenseType LicTypeNavigation { get; set; }
        public LicenseBigR LicenseBigR { get; set; }
        public ICollection<BrRegItem> BrRegItem { get; set; }
        public ICollection<LicPlace> LicPlace { get; set; }
        public ICollection<License> License { get; set; }
        public ICollection<LicenseAgrParam> LicenseAgrParam { get; set; }
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
    }
}

