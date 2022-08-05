using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicenseMethodType
    {
        public LicenseMethodType()
        {
            LicenseAgreement = new HashSet<LicenseAgreement>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LicenseAgreement> LicenseAgreement { get; set; }
    }
}
