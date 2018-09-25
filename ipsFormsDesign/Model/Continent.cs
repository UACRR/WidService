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

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<ContinentTr> ContinentTr { get; set; }
        public ObservableListSource<Country> Country { get; set; }
        public ObservableListSource<ReqLocationUse> ReqLocationUse { get; set; }
    }
}

