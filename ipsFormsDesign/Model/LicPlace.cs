using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class licPlace : IlicPlace
    {
        public int licId { get; set; }
        public int placeId { get; set; }

        public LicenseAgreement lic { get; set; }
        public ClnBusinessPlace place { get; set; }
    }
}

