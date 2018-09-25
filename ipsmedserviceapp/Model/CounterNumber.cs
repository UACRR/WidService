using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CounterNumber
    {
        public CounterNumber()
        {
            relCounterDoc = new HashSet<relCounterDoc>();
        }

        public int counterId { get; set; }
        public string name { get; set; }
        public int? cNum { get; set; }
        public string prefix { get; set; }
        public string symbolN { get; set; }
        public short? templYear { get; set; }

        public ICollection<relCounterDoc> relCounterDoc { get; set; }
    }
}
