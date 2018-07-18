using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Country : ICountry
    {
        public Country()
        {
            AnketaCompanyFaCountryNavigation = new ObservableListSource<AnketaCompany>();
            AnketaCompanyJaCountryNavigation = new ObservableListSource<AnketaCompany>();
            AnketaCompanyLeCountryNavigation = new ObservableListSource<AnketaCompany>();
            AnketaExternal = new ObservableListSource<AnketaExternal>();
            AnketaPersonCitizenshipNavigation = new ObservableListSource<AnketaPerson>();
            AnketaPersonFaCountryNavigation = new ObservableListSource<AnketaPerson>();
            AnketaPersonReCountryNavigation = new ObservableListSource<AnketaPerson>();
            CountryTr = new ObservableListSource<CountryTr>();
            KlR030 = new ObservableListSource<KlR030>();
            ReqCustomer = new ObservableListSource<ReqCustomer>();
            ReqLocationUse = new ObservableListSource<ReqLocationUse>();
            TerritoryExclude = new ObservableListSource<TerritoryExclude>();
            TerritoryInclude = new ObservableListSource<TerritoryInclude>();
        }

        public int? ContinentCode { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string A2 { get; set; }
        public string KOdLit { get; set; }
        public string CountryNameShort { get; set; }
        public short? ShortChoise { get; set; }
        public int? OrderBy { get; set; }

        public Continent ContinentCodeNavigation { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompanyFaCountryNavigation { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompanyJaCountryNavigation { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompanyLeCountryNavigation { get; set; }
        public ObservableListSource<AnketaExternal> AnketaExternal { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPersonCitizenshipNavigation { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPersonFaCountryNavigation { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPersonReCountryNavigation { get; set; }
        public ObservableListSource<CountryTr> CountryTr { get; set; }
        public ObservableListSource<KlR030> KlR030 { get; set; }
        public ObservableListSource<ReqCustomer> ReqCustomer { get; set; }
        public ObservableListSource<ReqLocationUse> ReqLocationUse { get; set; }
        public ObservableListSource<TerritoryExclude> TerritoryExclude { get; set; }
        public ObservableListSource<TerritoryInclude> TerritoryInclude { get; set; }
    }
}

