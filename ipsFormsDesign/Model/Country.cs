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

        public virtual Continent ContinentCodeNavigation { get; set; }
        public virtual ObservableListSource<AnketaCompany> AnketaCompanyFaCountryNavigation { get; set; }
        public virtual ObservableListSource<AnketaCompany> AnketaCompanyJaCountryNavigation { get; set; }
        public virtual ObservableListSource<AnketaCompany> AnketaCompanyLeCountryNavigation { get; set; }
        public virtual ObservableListSource<AnketaExternal> AnketaExternal { get; set; }
        public virtual ObservableListSource<AnketaPerson> AnketaPersonCitizenshipNavigation { get; set; }
        public virtual ObservableListSource<AnketaPerson> AnketaPersonFaCountryNavigation { get; set; }
        public virtual ObservableListSource<AnketaPerson> AnketaPersonReCountryNavigation { get; set; }
        public virtual ObservableListSource<CountryTr> CountryTr { get; set; }
        public virtual ObservableListSource<KlR030> KlR030 { get; set; }
        public virtual ObservableListSource<ReqCustomer> ReqCustomer { get; set; }
        public virtual ObservableListSource<TerritoryExclude> TerritoryExclude { get; set; }
        public virtual ObservableListSource<TerritoryInclude> TerritoryInclude { get; set; }
    }
}

