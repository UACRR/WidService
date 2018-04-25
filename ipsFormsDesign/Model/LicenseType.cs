using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicenseType
    {
        public LicenseType()
        {
            LicenseTypeTr = new HashSet<LicenseTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<LicenseTypeTr> LicenseTypeTr { get; set; }
    }
}
