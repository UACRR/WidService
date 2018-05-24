using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicPlaceHoll : ILicPlaceHoll
    {
        public int LicId { get; set; }
        public int PlaceId { get; set; }
        public int HollId { get; set; }

        public ClnPlaceHoll Holl { get; set; }
        public LicPlace LicPlace { get; set; }
    }
}

