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

        public int licId { get; set; }
        public DateTime? datePremiere { get; set; }
        public int? objId { get; set; }
        public decimal? fillingRate { get; set; }
        public int? performNumb { get; set; }
        public decimal? ticketPriceNC { get; set; }
        public decimal? ticketPriceUSD { get; set; }
        public bool? isTour { get; set; }
        public string whereTour { get; set; }
        public decimal? rate { get; set; }
        public decimal? prepayRest { get; set; }
        public string langCode { get; set; }
        public int? performType { get; set; }
        public short? licTerm { get; set; }
        public decimal? rateMusic { get; set; }

        [JsonIgnore]
        public Language langCodeNavigation { get; set; }
        [JsonIgnore]
        public LicenseAgreement lic { get; set; }
        public ObjectRight obj { get; set; }
        [JsonIgnore]
        public PerformType performTypeNavigation { get; set; }
        public ICollection<MusicalDesign> MusicalDesign { get; set; }
    }
}

