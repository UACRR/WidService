using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class relLicCopyR
    {
        public int agrLlicCode { get; set; }
        public int cRKindCode { get; set; }

        public AgrLicenseType agrLlicCodeNavigation { get; set; }
        public CopyrightKind cRKindCodeNavigation { get; set; }
    }
}
