using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MusicalDesign
    {
        public int mdId { get; set; }
        public int licId { get; set; }
        public int? objid { get; set; }
        public int? actNumb { get; set; }
        public string objName { get; set; }
        public string nameMusician { get; set; }
        public string nameSinger { get; set; }
        public string authorText { get; set; }
        public TimeSpan? duration { get; set; }
        public int? numbPerfom { get; set; }

        [JsonIgnore]
        public LicenseBigR lic { get; set; }
        [JsonIgnore]
        public ObjectRight obj { get; set; }
    }
}

