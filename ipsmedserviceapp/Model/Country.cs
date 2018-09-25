using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Country
    {
        public Country()
        {
            AnketaCompanyFaCountryNavigation = new HashSet<AnketaCompany>();
            AnketaCompanyJaCountryNavigation = new HashSet<AnketaCompany>();
            AnketaCompanyLeCountryNavigation = new HashSet<AnketaCompany>();
            AnketaExternal = new HashSet<AnketaExternal>();
            AnketaPersonCitizenshipNavigation = new HashSet<AnketaPerson>();
            AnketaPersonFaCountryNavigation = new HashSet<AnketaPerson>();
            AnketaPersonReCountryNavigation = new HashSet<AnketaPerson>();
            CountryTr = new HashSet<CountryTr>();
            KlR030 = new HashSet<KlR030>();
            ReqCustomer = new HashSet<ReqCustomer>();
            ReqLocationUse = new HashSet<ReqLocationUse>();
            TerritoryExclude = new HashSet<TerritoryExclude>();
            TerritoryInclude = new HashSet<TerritoryInclude>();
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
        public ICollection<AnketaCompany> AnketaCompanyFaCountryNavigation { get; set; }
        public ICollection<AnketaCompany> AnketaCompanyJaCountryNavigation { get; set; }
        public ICollection<AnketaCompany> AnketaCompanyLeCountryNavigation { get; set; }
        public ICollection<AnketaExternal> AnketaExternal { get; set; }
        public ICollection<AnketaPerson> AnketaPersonCitizenshipNavigation { get; set; }
        public ICollection<AnketaPerson> AnketaPersonFaCountryNavigation { get; set; }
        public ICollection<AnketaPerson> AnketaPersonReCountryNavigation { get; set; }
        public ICollection<CountryTr> CountryTr { get; set; }
        public ICollection<KlR030> KlR030 { get; set; }
        public ICollection<ReqCustomer> ReqCustomer { get; set; }
        public ICollection<ReqLocationUse> ReqLocationUse { get; set; }
        public ICollection<TerritoryExclude> TerritoryExclude { get; set; }
        public ICollection<TerritoryInclude> TerritoryInclude { get; set; }
    }
}
