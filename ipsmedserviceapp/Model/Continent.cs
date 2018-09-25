using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Continent
    {
        public Continent()
        {
            ContinentTr = new HashSet<ContinentTr>();
            Country = new HashSet<Country>();
            ReqLocationUse = new HashSet<ReqLocationUse>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<ContinentTr> ContinentTr { get; set; }
        public ICollection<Country> Country { get; set; }
        public ICollection<ReqLocationUse> ReqLocationUse { get; set; }
    }
}
