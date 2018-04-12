using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Country
    {
        public Country()
        {
            CountryTr = new HashSet<CountryTr>();
            KlR030 = new HashSet<KlR030>();
            Region = new HashSet<Region>();
        }

        public int? ContinentCode { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string A2 { get; set; }
        public string KOdLit { get; set; }
        public string CountryNameShort { get; set; }
        public short? ShortChoise { get; set; }
        public int? OrderBy { get; set; }

        public ICollection<CountryTr> CountryTr { get; set; }
        public ICollection<KlR030> KlR030 { get; set; }
        public ICollection<Region> Region { get; set; }
    }
}
