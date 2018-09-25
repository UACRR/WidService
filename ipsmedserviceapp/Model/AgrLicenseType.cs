using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgrLicenseType
    {
        public AgrLicenseType()
        {
            AgrLicenseTypeTr = new HashSet<AgrLicenseTypeTr>();
            LicenseAgreement = new HashSet<LicenseAgreement>();
            RelCounterDoc = new HashSet<RelCounterDoc>();
            RelLicCopyR = new HashSet<RelLicCopyR>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? KindCode { get; set; }
        public int? UsesKind { get; set; }
        public string TemplateName { get; set; }
        public bool? NeedPlace { get; set; }
        public int? SchemaId { get; set; }
        public int? AlgorithmId { get; set; }

        public AlgorithmType Algorithm { get; set; }
        public CopyrightKind KindCodeNavigation { get; set; }
        public UsesKind UsesKindNavigation { get; set; }
        public ICollection<AgrLicenseTypeTr> AgrLicenseTypeTr { get; set; }
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
        public ICollection<RelCounterDoc> RelCounterDoc { get; set; }
        public ICollection<RelLicCopyR> RelLicCopyR { get; set; }
    }
}
