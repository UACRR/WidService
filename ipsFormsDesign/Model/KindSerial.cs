using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class KindSerial : IKindSerial
    {
        public KindSerial()
        {
            KindSerialTr = new ObservableListSource<KindSerialTr>();
            RequestSerial = new ObservableListSource<RequestSerial>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<KindSerialTr> KindSerialTr { get; set; }
        public virtual ObservableListSource<RequestSerial> RequestSerial { get; set; }
    }
}

