using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Period
    {
        public Period()
        {
            AgreementAddBR = new HashSet<AgreementAddBR>();
            AgreementAddPartner = new HashSet<AgreementAddPartner>();
            AgreementAddRH = new HashSet<AgreementAddRH>();
            LicenseAgrParam = new HashSet<LicenseAgrParam>();
            PaidPeriod = new HashSet<PaidPeriod>();
            PeriodTr = new HashSet<PeriodTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public string nameR { get; set; }

        public ICollection<AgreementAddBR> AgreementAddBR { get; set; }
        public ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ICollection<AgreementAddRH> AgreementAddRH { get; set; }
        public ICollection<LicenseAgrParam> LicenseAgrParam { get; set; }
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
        public ICollection<PeriodTr> PeriodTr { get; set; }
    }
}
