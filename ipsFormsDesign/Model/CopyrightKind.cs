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
            TermsOfService = new ObservableListSource<TermsOfService>();
            relLicCopyR = new ObservableListSource<relLicCopyR>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public int? crGroupCode { get; set; }

        public CRKindGroup crGroupCodeNavigation { get; set; }
        public PortalSupportRights PortalSupportRights { get; set; }
        public ObservableListSource<AgrLicenseType> AgrLicenseType { get; set; }
        public ObservableListSource<CopyrightKindTr> CopyrightKindTr { get; set; }
        public ObservableListSource<Distribution> Distribution { get; set; }
        public ObservableListSource<RegisterCount> RegisterCount { get; set; }
        public ObservableListSource<TermsOfService> TermsOfService { get; set; }
        public ObservableListSource<relLicCopyR> relLicCopyR { get; set; }
    }
}

