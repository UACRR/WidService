using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicPlace
    {
        public int LicId { get; set; }
        public int PlaceId { get; set; }

        public virtual LicenseAgreement Lic { get; set; }
        public virtual ClnBusinessPlace Place { get; set; }
    }
}
