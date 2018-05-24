using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgrLicenseType : IAgrLicenseType
    {
        public AgrLicenseType()
        {
            AgrLicenseTypeTr = new HashSet<AgrLicenseTypeTr>();
            LicenseAgreement = new HashSet<LicenseAgreement>();
            RelLicCopyR = new HashSet<RelLicCopyR>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? KindCode { get; set; }
        public int? UsesKind { get; set; }
        public string TemplateName { get; set; }

        public CopyrightKind KindCodeNavigation { get; set; }
        public UsesKind UsesKindNavigation { get; set; }
        public ICollection<AgrLicenseTypeTr> AgrLicenseTypeTr { get; set; }
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
        public ICollection<RelLicCopyR> RelLicCopyR { get; set; }
    }
}

