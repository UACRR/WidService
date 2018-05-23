using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicenseClass : ILicenseClass
    {
        public int CodeI { get; set; }
        public string Name { get; set; }
    }
}

