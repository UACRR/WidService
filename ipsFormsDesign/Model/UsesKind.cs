using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UsesKind : IUsesKind
    {
        public UsesKind()
        {
            AgrLicenseType = new HashSet<AgrLicenseType>();
        }

        public int CodeI { get; set; }
        public int? UsesType { get; set; }
        public string Name { get; set; }

        public UsesType UsesTypeNavigation { get; set; }
        public ICollection<AgrLicenseType> AgrLicenseType { get; set; }
    }
}

