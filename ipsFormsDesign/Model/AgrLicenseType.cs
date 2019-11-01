using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
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
        public string Series { get; set; }
        public decimal? AuthRate { get; set; }
        public short? IsPortal { get; set; }

        [JsonIgnore]
        public virtual AlgorithmType Algorithm { get; set; }
        [JsonIgnore]
        public virtual CopyrightKind KindCodeNavigation { get; set; }
        public virtual UsesKind UsesKindNavigation { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<AgrLicenseTypeTr> AgrLicenseTypeTr { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<RelCounterDoc> RelCounterDoc { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<RelLicCopyR> RelLicCopyR { get; set; }
    }
}


