using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CounterNumber
    {
        public CounterNumber()
        {
            RelCounterDoc = new HashSet<RelCounterDoc>();
        }

        public int CounterId { get; set; }
        public string Name { get; set; }
        public int? CNum { get; set; }
        public string Prefix { get; set; }
        public string SymbolN { get; set; }
        public short? TemplYear { get; set; }

        public ICollection<RelCounterDoc> RelCounterDoc { get; set; }
    }
}
