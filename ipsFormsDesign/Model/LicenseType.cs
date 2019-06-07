using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicenseType : ILicenseType
    {
        public LicenseType()
        {
            LicenseAgreement = new ObservableListSource<LicenseAgreement>();
            LicenseTypeTr = new ObservableListSource<LicenseTypeTr>();
            Request = new ObservableListSource<Request>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
        public virtual ObservableListSource<LicenseTypeTr> LicenseTypeTr { get; set; }
        public virtual ObservableListSource<Request> Request { get; set; }
    }
}

