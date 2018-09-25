using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Period
    {
        public Period()
        {
            AgreementAddBr = new HashSet<AgreementAddBr>();
            AgreementAddPartner = new HashSet<AgreementAddPartner>();
            AgreementAddRh = new HashSet<AgreementAddRh>();
            LicenseAgrParam = new HashSet<LicenseAgrParam>();
            PaidPeriod = new HashSet<PaidPeriod>();
            PeriodTr = new HashSet<PeriodTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public string NameR { get; set; }

        public ICollection<AgreementAddBr> AgreementAddBr { get; set; }
        public ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        public ICollection<LicenseAgrParam> LicenseAgrParam { get; set; }
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
        public ICollection<PeriodTr> PeriodTr { get; set; }
    }
}
