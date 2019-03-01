using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Continent : IContinent
    {
        public Continent()
        {
            ContinentTr = new ObservableListSource<ContinentTr>();
            Country = new ObservableListSource<Country>();
            ReqLocationUse = new ObservableListSource<ReqLocationUse>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<ContinentTr> ContinentTr { get; set; }
        public virtual ObservableListSource<Country> Country { get; set; }
        public virtual ObservableListSource<ReqLocationUse> ReqLocationUse { get; set; }
    }
}

