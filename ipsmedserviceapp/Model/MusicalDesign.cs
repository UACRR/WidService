using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MusicalDesign
    {
        public int MdId { get; set; }
        public int LicId { get; set; }
        public int? Objid { get; set; }
        public int? ActNumb { get; set; }
        public string ObjName { get; set; }
        public string NameMusician { get; set; }
        public string NameSinger { get; set; }
        public string AuthorText { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? NumbPerfom { get; set; }

        [JsonIgnore]
        public virtual LicenseBigR Lic { get; set; }
        public virtual ObjectRight Obj { get; set; }
    }
}


