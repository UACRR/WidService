using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgrLicenseType : IAgrLicenseType
    {
        public AgrLicenseType()
        {
            AgrLicenseTypeTr = new ObservableListSource<AgrLicenseTypeTr>();
            LicenseAgreement = new ObservableListSource<LicenseAgreement>();
            relCounterDoc = new ObservableListSource<relCounterDoc>();
            relLicCopyR = new ObservableListSource<relLicCopyR>();
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
        public ObservableListSource<AgrLicenseTypeTr> AgrLicenseTypeTr { get; set; }
        public ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
        public ObservableListSource<relCounterDoc> relCounterDoc { get; set; }
        public ObservableListSource<relLicCopyR> relLicCopyR { get; set; }
    }
}

