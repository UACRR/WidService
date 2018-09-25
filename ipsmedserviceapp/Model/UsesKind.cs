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

        public int codeI { get; set; }
        public int? usesType { get; set; }
        public string name { get; set; }

        public UsesType usesTypeNavigation { get; set; }
        public ICollection<AgrLicenseType> AgrLicenseType { get; set; }
        public ICollection<UsesKindTr> UsesKindTr { get; set; }
    }
}
