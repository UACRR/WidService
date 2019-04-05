using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.InternalControlsModel
{
    public class PlacesForAgreement : ClnBusinessPlace
    {
        public string FullAddressPlace { get; set; }

        public static List<PlacesForAgreement> Convert(IList<ClnBusinessPlace> clnBusinessPlaces)
        {
            List<PlacesForAgreement> list = new List<PlacesForAgreement>();
            foreach (var clnBusinessPlace in clnBusinessPlaces)
            {
                var place = new PlacesForAgreement
                {
                    PlaceId = clnBusinessPlace.PlaceId,
                    CustId = clnBusinessPlace.CustId,
                    PlCode = clnBusinessPlace.PlCode,
                    PlaceAddress = clnBusinessPlace.PlaceAddress,
                    PlaceCity = clnBusinessPlace.PlaceCity,
                    PlaceCountry = clnBusinessPlace.PlaceCountry,
                    PlaceRegion = clnBusinessPlace.PlaceRegion,
                    PlaceName = clnBusinessPlace.PlaceName,

                    ClnPlaceHoll = clnBusinessPlace.ClnPlaceHoll,
                    License = clnBusinessPlace.License,
                    FreeEntry = clnBusinessPlace.FreeEntry,
                    Cust = clnBusinessPlace.Cust,
                    LicPlace = clnBusinessPlace.LicPlace,
                    PlacePhone = clnBusinessPlace.PlacePhone,
                    PlCodeNavigation = clnBusinessPlace.PlCodeNavigation,
                };
                string fullAddress = string.Empty;

                if (IpsGlobal.AnketaDictionaties != null)
                {
                    var regionName = IpsGlobal.AnketaDictionaties.region.SingleOrDefault(rec => rec.CodeI == place.PlaceRegion)?.Name;
                    if (!string.IsNullOrEmpty(regionName))
                    {
                        fullAddress += regionName;
                        fullAddress += place.PlaceRegion == 25 ? ", " : " обл., ";
                    }
                }

                // м. Київ - дубль
                if (place.PlaceRegion != 25 && !string.IsNullOrEmpty(place.PlaceCity))
                    fullAddress += $"{place.PlaceCity}, ";

                fullAddress += $"{place.PlaceAddress}";

                place.FullAddressPlace = fullAddress;
                
                list.Add(place);
            }
            return list;
        }
    }
}
