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
        public virtual Client Cust { get; set; }
        public virtual AgrLicenseType LicCodeNavigation { get; set; }
        public virtual LicenseMethodType LicMethodNavigation { get; set; }
        public virtual AgreementStatus LicStatusNavigation { get; set; }
        public virtual LicenseType LicTypeNavigation { get; set; }
        public virtual LicenseBigR LicenseBigR { get; set; }
        public virtual ICollection<BrRegItem> BrRegItem { get; set; }
        public virtual ICollection<Fixation> Fixation { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<LicPlace> LicPlace { get; set; }
        public virtual ICollection<LicenseAgrParam> LicenseAgrParam { get; set; }
        public virtual ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public virtual ICollection<PaidPeriod> PaidPeriod { get; set; }
    }
}
