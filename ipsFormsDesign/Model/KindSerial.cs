using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class KindSerial : IKindSerial
    {
        public KindSerial()
        {
            KindSerialTr = new HashSet<KindSerialTr>();
            RequestSerial = new HashSet<RequestSerial>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<KindSerialTr> KindSerialTr { get; set; }
        public ICollection<RequestSerial> RequestSerial { get; set; }
    }
}

