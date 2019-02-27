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

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ContinentTr> ContinentTr { get; set; }
        public virtual ICollection<Country> Country { get; set; }
        public virtual ICollection<ReqLocationUse> ReqLocationUse { get; set; }
    }
}
