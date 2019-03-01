using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelCounterDoc
    {
        public int CDocId { get; set; }
        public int CounterId { get; set; }
        public int DocType { get; set; }
        public int? LicType { get; set; }

        public virtual CounterNumber Counter { get; set; }
        public virtual DocumentType DocTypeNavigation { get; set; }
        public virtual AgrLicenseType LicTypeNavigation { get; set; }
    }
}
