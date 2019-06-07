using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CopyrightKind : ICopyrightKind
    {
        public CopyrightKind()
        {
            AgrLicenseType = new ObservableListSource<AgrLicenseType>();
            CopyrightKindTr = new ObservableListSource<CopyrightKindTr>();
            Distribution = new ObservableListSource<Distribution>();
            RegisterCount = new ObservableListSource<RegisterCount>();
            RelLicCopyR = new ObservableListSource<RelLicCopyR>();
            TermsOfService = new ObservableListSource<TermsOfService>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int CrGroupCode { get; set; }
        public string NameDescript { get; set; }

        public virtual CrkindGroup CrGroupCodeNavigation { get; set; }
        public virtual PortalSupportRights PortalSupportRights { get; set; }
        public virtual ObservableListSource<AgrLicenseType> AgrLicenseType { get; set; }
        public virtual ObservableListSource<CopyrightKindTr> CopyrightKindTr { get; set; }
        public virtual ObservableListSource<Distribution> Distribution { get; set; }
        public virtual ObservableListSource<RegisterCount> RegisterCount { get; set; }
        public virtual ObservableListSource<RelLicCopyR> RelLicCopyR { get; set; }
        public virtual ObservableListSource<TermsOfService> TermsOfService { get; set; }
    }
}

