using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CounterNumber : ICounterNumber
    {
        public CounterNumber()
        {
            relCounterDoc = new ObservableListSource<relCounterDoc>();
        }

        public int counterId { get; set; }
        public string name { get; set; }
        public int? cNum { get; set; }
        public string prefix { get; set; }
        public string symbolN { get; set; }
        public short? templYear { get; set; }

        public ObservableListSource<relCounterDoc> relCounterDoc { get; set; }
    }
}

