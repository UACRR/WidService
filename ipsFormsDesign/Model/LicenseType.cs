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

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
        public ObservableListSource<LicenseTypeTr> LicenseTypeTr { get; set; }
        public ObservableListSource<Request> Request { get; set; }
    }
}

