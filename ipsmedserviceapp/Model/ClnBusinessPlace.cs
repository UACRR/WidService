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
            LicPlace = new HashSet<LicPlace>();
            License = new HashSet<License>();
        }

        public int PlaceId { get; set; }
        public int? CustId { get; set; }
        public int? PlCode { get; set; }
        public string PlaceName { get; set; }
        public string PlaceCountry { get; set; }
        public int? PlaceRegion { get; set; }
        public string PlaceCity { get; set; }
        public string PlaceAddress { get; set; }
        public string PlacePhone { get; set; }
        public bool? FreeEntry { get; set; }

        [JsonIgnore]
        public Client Cust { get; set; }
        public TypePlace PlCodeNavigation { get; set; }
        public ICollection<ClnPlaceHoll> ClnPlaceHoll { get; set; }
        [JsonIgnore]
        public ICollection<LicPlace> LicPlace { get; set; }
        [JsonIgnore]
        public ICollection<License> License { get; set; }
    }
}




