using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelLicCopyR : IRelLicCopyR
    {
        public int AgrLlicCode { get; set; }
        public int CRkindCode { get; set; }

        public virtual AgrLicenseType AgrLlicCodeNavigation { get; set; }
        public virtual CopyrightKind CRkindCodeNavigation { get; set; }
    }
}

