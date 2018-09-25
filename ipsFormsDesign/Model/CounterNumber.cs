using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CounterNumber : ICounterNumber
    {
        public CounterNumber()
        {
            RelCounterDoc = new ObservableListSource<RelCounterDoc>();
        }

        public int CounterId { get; set; }
        public string Name { get; set; }
        public int? CNum { get; set; }
        public string Prefix { get; set; }
        public string SymbolN { get; set; }
        public short? TemplYear { get; set; }

        public ObservableListSource<RelCounterDoc> RelCounterDoc { get; set; }
    }
}

