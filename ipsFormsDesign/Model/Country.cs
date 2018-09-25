using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Country : ICountry
    {
        public Country()
        {
            AnketaCompanyfaCountryNavigation = new ObservableListSource<AnketaCompany>();
            AnketaCompanyjaCountryNavigation = new ObservableListSource<AnketaCompany>();
            AnketaCompanyleCountryNavigation = new ObservableListSource<AnketaCompany>();
            AnketaExternal = new ObservableListSource<AnketaExternal>();
            AnketaPersoncitizenshipNavigation = new ObservableListSource<AnketaPerson>();
            AnketaPersonfaCountryNavigation = new ObservableListSource<AnketaPerson>();
            AnketaPersonreCountryNavigation = new ObservableListSource<AnketaPerson>();
            CountryTr = new ObservableListSource<CountryTr>();
            KL_R030 = new ObservableListSource<KL_R030>();
            ReqCustomer = new ObservableListSource<ReqCustomer>();
            ReqLocationUse = new ObservableListSource<ReqLocationUse>();
            TerritoryExclude = new ObservableListSource<TerritoryExclude>();
            TerritoryInclude = new ObservableListSource<TerritoryInclude>();
        }

        public int? continentCode { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string a2 { get; set; }
        public string kOD_LIT { get; set; }
        public string countryNameShort { get; set; }
        public short? shortChoise { get; set; }
        public int? orderBy { get; set; }

        public Continent continentCodeNavigation { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompanyfaCountryNavigation { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompanyjaCountryNavigation { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompanyleCountryNavigation { get; set; }
        public ObservableListSource<AnketaExternal> AnketaExternal { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPersoncitizenshipNavigation { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPersonfaCountryNavigation { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPersonreCountryNavigation { get; set; }
        public ObservableListSource<CountryTr> CountryTr { get; set; }
        public ObservableListSource<KL_R030> KL_R030 { get; set; }
        public ObservableListSource<ReqCustomer> ReqCustomer { get; set; }
        public ObservableListSource<ReqLocationUse> ReqLocationUse { get; set; }
        public ObservableListSource<TerritoryExclude> TerritoryExclude { get; set; }
        public ObservableListSource<TerritoryInclude> TerritoryInclude { get; set; }
    }
}

