using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicPlace
    {
        public int LicId { get; set; }
        public int PlaceId { get; set; }

        public LicenseAgreement Lic { get; set; }
        public ClnBusinessPlace Place { get; set; }
    }
}
