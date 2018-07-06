using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicenseBigR
    {
        public LicenseBigR()
        {
            MusicalDesign = new HashSet<MusicalDesign>();
        }

        public int LicId { get; set; }
        public DateTime? DatePremiere { get; set; }
        public int? ObjId { get; set; }
        public decimal? FillingRate { get; set; }
        public int? PerformNumb { get; set; }
        public decimal? TicketPriceNc { get; set; }
        public decimal? TicketPriceUsd { get; set; }
        public bool? IsTour { get; set; }
        public string WhereTour { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? PrepayDateDo { get; set; }

        [JsonIgnore]
        public LicenseAgreement Lic { get; set; }
        public ObjectRight Obj { get; set; }
        [JsonIgnore]
        public ICollection<MusicalDesign> MusicalDesign { get; set; }
    }
}

