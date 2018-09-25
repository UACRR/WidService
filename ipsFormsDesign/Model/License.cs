using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class License : ILicense
    {
        public int lId { get; set; }
        public int? placeId { get; set; }
        public int? licId { get; set; }
        public int? licVersion { get; set; }
        public string lNum { get; set; }
        public DateTime? lDate { get; set; }
        public int? status { get; set; }

        public LicenseAgrParam lic { get; set; }
        public ClnBusinessPlace place { get; set; }
    }
}

