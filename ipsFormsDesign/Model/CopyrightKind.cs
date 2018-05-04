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
            RelLicCopyR = new HashSet<RelLicCopyR>();
            TermsOfService = new HashSet<TermsOfService>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? CrGroupCode { get; set; }

        public CrkindGroup CrGroupCodeNavigation { get; set; }
        public PortalSupportRights PortalSupportRights { get; set; }
        public ICollection<AgrLicenseType> AgrLicenseType { get; set; }
        public ICollection<CopyrightKindTr> CopyrightKindTr { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
        public ICollection<RegisterCount> RegisterCount { get; set; }
        public ICollection<RelLicCopyR> RelLicCopyR { get; set; }
        public ICollection<TermsOfService> TermsOfService { get; set; }
    }
}
