using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class licPlace
    {
        public int licId { get; set; }
        public int placeId { get; set; }

        public LicenseAgreement lic { get; set; }
        public ClnBusinessPlace place { get; set; }
    }
}
