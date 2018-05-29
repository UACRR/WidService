using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Continent : IContinent
    {
        public Continent()
        {
            ContinentTr = new HashSet<ContinentTr>();
            Country = new HashSet<Country>();
            ReqLocationUse = new HashSet<ReqLocationUse>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<ContinentTr> ContinentTr { get; set; }
        public ICollection<Country> Country { get; set; }
        public ICollection<ReqLocationUse> ReqLocationUse { get; set; }
    }
}

