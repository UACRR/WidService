using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgrLicenseType
    {
        public AgrLicenseType()
        {
            AgrLicenseTypeTr = new HashSet<AgrLicenseTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? KindCode { get; set; }
        public int? CategoryCode { get; set; }

        public CopyrightKind KindCodeNavigation { get; set; }
        public ICollection<AgrLicenseTypeTr> AgrLicenseTypeTr { get; set; }
    }
}
