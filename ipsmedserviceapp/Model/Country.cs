using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Country
    {
        public Country()
        {
            AnketaCompanyfaCountryNavigation = new HashSet<AnketaCompany>();
            AnketaCompanyjaCountryNavigation = new HashSet<AnketaCompany>();
            AnketaCompanyleCountryNavigation = new HashSet<AnketaCompany>();
            AnketaExternal = new HashSet<AnketaExternal>();
            AnketaPersoncitizenshipNavigation = new HashSet<AnketaPerson>();
            AnketaPersonfaCountryNavigation = new HashSet<AnketaPerson>();
            AnketaPersonreCountryNavigation = new HashSet<AnketaPerson>();
            CountryTr = new HashSet<CountryTr>();
            KL_R030 = new HashSet<KL_R030>();
            ReqCustomer = new HashSet<ReqCustomer>();
            ReqLocationUse = new HashSet<ReqLocationUse>();
            TerritoryExclude = new HashSet<TerritoryExclude>();
            TerritoryInclude = new HashSet<TerritoryInclude>();
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
        public ICollection<AnketaCompany> AnketaCompanyfaCountryNavigation { get; set; }
        public ICollection<AnketaCompany> AnketaCompanyjaCountryNavigation { get; set; }
        public ICollection<AnketaCompany> AnketaCompanyleCountryNavigation { get; set; }
        public ICollection<AnketaExternal> AnketaExternal { get; set; }
        public ICollection<AnketaPerson> AnketaPersoncitizenshipNavigation { get; set; }
        public ICollection<AnketaPerson> AnketaPersonfaCountryNavigation { get; set; }
        public ICollection<AnketaPerson> AnketaPersonreCountryNavigation { get; set; }
        public ICollection<CountryTr> CountryTr { get; set; }
        public ICollection<KL_R030> KL_R030 { get; set; }
        public ICollection<ReqCustomer> ReqCustomer { get; set; }
        public ICollection<ReqLocationUse> ReqLocationUse { get; set; }
        public ICollection<TerritoryExclude> TerritoryExclude { get; set; }
        public ICollection<TerritoryInclude> TerritoryInclude { get; set; }
    }
}
