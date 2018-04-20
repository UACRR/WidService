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
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<ContinentTr> ContinentTr { get; set; }
        public ICollection<Country> Country { get; set; }
    }
}
