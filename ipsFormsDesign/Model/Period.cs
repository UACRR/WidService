using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Period
    {
        public Period()
        {
            LicenseAgreement = new HashSet<LicenseAgreement>();
            PaidPeriod = new HashSet<PaidPeriod>();
            PeriodTr = new HashSet<PeriodTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
        public ICollection<PeriodTr> PeriodTr { get; set; }
    }
}
