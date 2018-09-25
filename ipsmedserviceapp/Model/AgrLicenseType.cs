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
            relCounterDoc = new HashSet<relCounterDoc>();
            relLicCopyR = new HashSet<relLicCopyR>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public int? kindCode { get; set; }
        public int? usesKind { get; set; }
        public string templateName { get; set; }
        public bool? needPlace { get; set; }
        public int? schemaId { get; set; }
        public int? algorithmId { get; set; }

        public AlgorithmType algorithm { get; set; }
        public CopyrightKind kindCodeNavigation { get; set; }
        public UsesKind usesKindNavigation { get; set; }
        public ICollection<AgrLicenseTypeTr> AgrLicenseTypeTr { get; set; }
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
        public ICollection<relCounterDoc> relCounterDoc { get; set; }
        public ICollection<relLicCopyR> relLicCopyR { get; set; }
    }
}
