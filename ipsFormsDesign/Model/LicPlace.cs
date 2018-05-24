using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicPlace : ILicPlace
    {
        public LicPlace()
        {
            LicPlaceHoll = new HashSet<LicPlaceHoll>();
        }

        public int LicId { get; set; }
        public int PlaceId { get; set; }

        public LicenseAgreement Lic { get; set; }
        public ClnBusinessPlace Place { get; set; }
        public ICollection<LicPlaceHoll> LicPlaceHoll { get; set; }
    }
}

