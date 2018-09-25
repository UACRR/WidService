using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class relLicCopyR : IrelLicCopyR
    {
        public int agrLlicCode { get; set; }
        public int cRKindCode { get; set; }

        public AgrLicenseType agrLlicCodeNavigation { get; set; }
        public CopyrightKind cRKindCodeNavigation { get; set; }
    }
}

