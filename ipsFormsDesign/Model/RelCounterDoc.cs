using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelCounterDoc : IRelCounterDoc
    {
        public int CDocId { get; set; }
        public int CounterId { get; set; }
        public int DocType { get; set; }
        public int? LicType { get; set; }

        public CounterNumber Counter { get; set; }
        public DocumentType DocTypeNavigation { get; set; }
        public AgrLicenseType LicTypeNavigation { get; set; }
    }
}

