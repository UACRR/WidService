using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
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

        [JsonIgnore]
        public virtual LicenseAgrParam Lic { get; set; }
        [JsonIgnore]
        public virtual ClnBusinessPlace Place { get; set; }
    }
}


