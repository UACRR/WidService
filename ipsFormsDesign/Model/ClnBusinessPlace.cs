using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ClnBusinessPlace : IClnBusinessPlace
    {
        public ClnBusinessPlace()
        {
            ClnPlaceHoll = new ObservableListSource<ClnPlaceHoll>();
            LicPlace = new ObservableListSource<LicPlace>();
            License = new ObservableListSource<License>();
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
        public virtual Client Cust { get; set; }
        public virtual TypePlace PlCodeNavigation { get; set; }
        public virtual ObservableListSource<ClnPlaceHoll> ClnPlaceHoll { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<LicPlace> LicPlace { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<License> License { get; set; }
    }
}




