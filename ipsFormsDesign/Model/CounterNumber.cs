using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CounterNumber : ICounterNumber
    {
        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? CNum { get; set; }
        public string Prefix { get; set; }
    }
}

