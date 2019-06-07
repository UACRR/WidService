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
        public int CrGroupCode { get; set; }
        public string NameDescript { get; set; }

        public virtual CrkindGroup CrGroupCodeNavigation { get; set; }
        public virtual PortalSupportRights PortalSupportRights { get; set; }
        public virtual ICollection<AgrLicenseType> AgrLicenseType { get; set; }
        public virtual ICollection<CopyrightKindTr> CopyrightKindTr { get; set; }
        public virtual ICollection<Distribution> Distribution { get; set; }
        public virtual ICollection<RegisterCount> RegisterCount { get; set; }
        public virtual ICollection<RelLicCopyR> RelLicCopyR { get; set; }
        public virtual ICollection<TermsOfService> TermsOfService { get; set; }
    }
}
