using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicenseClass
    {
        public LicenseClass()
        {
            AgrLicenseType = new HashSet<AgrLicenseType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AgrLicenseType> AgrLicenseType { get; set; }
    }
}
