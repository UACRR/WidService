using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class License
    {
        public int LId { get; set; }
        public int LicId { get; set; }
        public int? PlaceId { get; set; }
        public string LNum { get; set; }
        public DateTime? LDate { get; set; }
        public int? Status { get; set; }

        [JsonIgnore]
        public LicenseAgreement Lic { get; set; }
        [JsonIgnore]
        public ClnBusinessPlace Place { get; set; }
    }
}






