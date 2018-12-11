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
        public decimal? PrepayRest { get; set; }
        public string LangCode { get; set; }
        public int? PerformType { get; set; }
        public short? LicTerm { get; set; }
        public decimal? RateMusic { get; set; }

        [JsonIgnore]
        public Language LangCodeNavigation { get; set; }
        [JsonIgnore]
        public LicenseAgreement Lic { get; set; }
        public ObjectRight Obj { get; set; }
        [JsonIgnore]
        public PerformType PerformTypeNavigation { get; set; }
        public ICollection<MusicalDesign> MusicalDesign { get; set; }
    }
}


