using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicPlace : ILicPlace
    {
        public int LicId { get; set; }
        public int PlaceId { get; set; }

        public virtual LicenseAgreement Lic { get; set; }
        public virtual ClnBusinessPlace Place { get; set; }
    }
}

