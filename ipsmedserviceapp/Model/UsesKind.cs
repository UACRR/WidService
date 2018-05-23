using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UsesKind
    {
        public UsesKind()
        {
            AgrLicenseType = new HashSet<AgrLicenseType>();
            UsesKindTr = new HashSet<UsesKindTr>();
        }

        public int CodeI { get; set; }
        public int? UsesType { get; set; }
        public string Name { get; set; }

        public UsesType UsesTypeNavigation { get; set; }
        public ICollection<AgrLicenseType> AgrLicenseType { get; set; }
        public ICollection<UsesKindTr> UsesKindTr { get; set; }
    }
}
