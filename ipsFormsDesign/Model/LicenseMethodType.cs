using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicenseMethodType : ILicenseMethodType
    {
        public LicenseMethodType()
        {
            LicenseAgreement = new ObservableListSource<LicenseAgreement>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
    }
}

