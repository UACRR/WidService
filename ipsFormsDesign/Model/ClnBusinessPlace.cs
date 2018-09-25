using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ClnBusinessPlace : IClnBusinessPlace
    {
        public ClnBusinessPlace()
        {
            ClnPlaceHoll = new ObservableListSource<ClnPlaceHoll>();
            License = new ObservableListSource<License>();
            licPlace = new ObservableListSource<licPlace>();
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

        public Client cust { get; set; }
        public TypePlace plCodeNavigation { get; set; }
        public ObservableListSource<ClnPlaceHoll> ClnPlaceHoll { get; set; }
        public ObservableListSource<License> License { get; set; }
        public ObservableListSource<licPlace> licPlace { get; set; }
    }
}

