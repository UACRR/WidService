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
            Distribution = new HashSet<Distribution>();
            RegisterCount = new HashSet<RegisterCount>();
            TermsOfService = new HashSet<TermsOfService>();
            relLicCopyR = new HashSet<relLicCopyR>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public int? crGroupCode { get; set; }

        public CRKindGroup crGroupCodeNavigation { get; set; }
        public PortalSupportRights PortalSupportRights { get; set; }
        public ICollection<AgrLicenseType> AgrLicenseType { get; set; }
        public ICollection<CopyrightKindTr> CopyrightKindTr { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
        public ICollection<RegisterCount> RegisterCount { get; set; }
        public ICollection<TermsOfService> TermsOfService { get; set; }
        public ICollection<relLicCopyR> relLicCopyR { get; set; }
    }
}
