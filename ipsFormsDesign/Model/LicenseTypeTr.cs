using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicenseTypeTr : ILicenseTypeTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public LicenseType CodeINavigation { get; set; }
    }
}

