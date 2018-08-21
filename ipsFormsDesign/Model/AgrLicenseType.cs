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
            RelCounterDoc = new ObservableListSource<RelCounterDoc>();
            RelLicCopyR = new ObservableListSource<RelLicCopyR>();
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
        public ObservableListSource<AgrLicenseTypeTr> AgrLicenseTypeTr { get; set; }
        public ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
        public ObservableListSource<RelCounterDoc> RelCounterDoc { get; set; }
        public ObservableListSource<RelLicCopyR> RelLicCopyR { get; set; }
    }
}

