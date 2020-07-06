using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class License : ILicense
    {
        public int LId { get; set; }
        public int? PlaceId { get; set; }
        public int? LicId { get; set; }
        public int? LicVersion { get; set; }
        public string LNum { get; set; }
        public DateTime? LDate { get; set; }
        public int? Status { get; set; }

        public virtual LicenseAgrParam Lic { get; set; }
        public virtual ClnBusinessPlace Place { get; set; }
    }
}

