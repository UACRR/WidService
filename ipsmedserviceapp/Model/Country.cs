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

        public virtual Continent ContinentCodeNavigation { get; set; }
        public virtual ICollection<AnketaCompany> AnketaCompanyFaCountryNavigation { get; set; }
        public virtual ICollection<AnketaCompany> AnketaCompanyJaCountryNavigation { get; set; }
        public virtual ICollection<AnketaCompany> AnketaCompanyLeCountryNavigation { get; set; }
        public virtual ICollection<AnketaExternal> AnketaExternal { get; set; }
        public virtual ICollection<AnketaPerson> AnketaPersonCitizenshipNavigation { get; set; }
        public virtual ICollection<AnketaPerson> AnketaPersonFaCountryNavigation { get; set; }
        public virtual ICollection<AnketaPerson> AnketaPersonReCountryNavigation { get; set; }
        public virtual ICollection<CountryTr> CountryTr { get; set; }
        public virtual ICollection<KlR030> KlR030 { get; set; }
        public virtual ICollection<ReqCustomer> ReqCustomer { get; set; }
        public virtual ICollection<TerritoryExclude> TerritoryExclude { get; set; }
        public virtual ICollection<TerritoryInclude> TerritoryInclude { get; set; }
    }
}
