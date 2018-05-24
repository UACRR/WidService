using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicenseType : ILicenseType
    {
        public LicenseType()
        {
            LicenseAgreement = new HashSet<LicenseAgreement>();
            LicenseTypeTr = new HashSet<LicenseTypeTr>();
            Request = new HashSet<Request>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
        public ICollection<LicenseTypeTr> LicenseTypeTr { get; set; }
        public ICollection<Request> Request { get; set; }
    }
}

