using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelLicCopyR
    {
        public int AgrLlicCode { get; set; }
        public int CRkindCode { get; set; }

        public AgrLicenseType AgrLlicCodeNavigation { get; set; }
        public CopyrightKind CRkindCodeNavigation { get; set; }
    }
}
