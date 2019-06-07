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
        public string Series { get; set; }
        public decimal? AuthRate { get; set; }
        public short? IsPortal { get; set; }

        public virtual AlgorithmType Algorithm { get; set; }
        public virtual CopyrightKind KindCodeNavigation { get; set; }
        public virtual UsesKind UsesKindNavigation { get; set; }
        public virtual ICollection<AgrLicenseTypeTr> AgrLicenseTypeTr { get; set; }
        public virtual ICollection<LicenseAgreement> LicenseAgreement { get; set; }
        public virtual ICollection<RelCounterDoc> RelCounterDoc { get; set; }
        public virtual ICollection<RelLicCopyR> RelLicCopyR { get; set; }
    }
}
