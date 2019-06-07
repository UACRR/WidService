using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Period
    {
        public Period()
        {
            AgreementAddBr = new HashSet<AgreementAddBr>();
            AgreementAddCommunity = new HashSet<AgreementAddCommunity>();
            AgreementAddPartner = new HashSet<AgreementAddPartner>();
            AgreementAddRh = new HashSet<AgreementAddRh>();
            LicenseAgrParam = new HashSet<LicenseAgrParam>();
            PaidPeriod = new HashSet<PaidPeriod>();
            PeriodTr = new HashSet<PeriodTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public string NameR { get; set; }

        public virtual ICollection<AgreementAddBr> AgreementAddBr { get; set; }
        public virtual ICollection<AgreementAddCommunity> AgreementAddCommunity { get; set; }
        public virtual ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public virtual ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        public virtual ICollection<LicenseAgrParam> LicenseAgrParam { get; set; }
        public virtual ICollection<PaidPeriod> PaidPeriod { get; set; }
        public virtual ICollection<PeriodTr> PeriodTr { get; set; }
    }
}
