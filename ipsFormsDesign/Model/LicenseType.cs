using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicenseType
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
