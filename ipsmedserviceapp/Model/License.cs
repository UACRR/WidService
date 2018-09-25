using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class License
    {
        public int lId { get; set; }
        public int? placeId { get; set; }
        public int? licId { get; set; }
        public int? licVersion { get; set; }
        public string lNum { get; set; }
        public DateTime? lDate { get; set; }
        public int? status { get; set; }

        [JsonIgnore]
        public LicenseAgrParam lic { get; set; }
        [JsonIgnore]
        public ClnBusinessPlace place { get; set; }
    }
}

