using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CopyrightKind
    {
        public CopyrightKind()
        {
            AgrLicenseType = new HashSet<AgrLicenseType>();
            CopyrightKindTr = new HashSet<CopyrightKindTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? CrGroupCode { get; set; }

        public CrkindGroup CrGroupCodeNavigation { get; set; }
        public ICollection<AgrLicenseType> AgrLicenseType { get; set; }
        public ICollection<CopyrightKindTr> CopyrightKindTr { get; set; }
    }
}
