using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ClnBusinessPlace
    {
        public ClnBusinessPlace()
        {
            ClnPlaceHoll = new HashSet<ClnPlaceHoll>();
            License = new HashSet<License>();
            licPlace = new HashSet<licPlace>();
        }

        public int placeId { get; set; }
        public int? custId { get; set; }
        public int? plCode { get; set; }
        public string placeName { get; set; }
        public string placeCountry { get; set; }
        public int? placeRegion { get; set; }
        public string placeCity { get; set; }
        public string placeAddress { get; set; }
        public string placePhone { get; set; }
        public bool? freeEntry { get; set; }

        [JsonIgnore]
        public Client cust { get; set; }
        [JsonIgnore]
        public TypePlace plCodeNavigation { get; set; }
        public ICollection<ClnPlaceHoll> ClnPlaceHoll { get; set; }
        [JsonIgnore]
        public ICollection<License> License { get; set; }
        [JsonIgnore]
        public ICollection<licPlace> licPlace { get; set; }
    }
}

