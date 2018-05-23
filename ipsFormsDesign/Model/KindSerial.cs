using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class KindSerial : IKindSerial
    {
        public KindSerial()
        {
            RequestSerial = new HashSet<RequestSerial>();
        }

        public int KindSerialCode { get; set; }
        public string KindSerialNameUk { get; set; }
        public string KindSerialNameRu { get; set; }
        public string KindSerialNameEn { get; set; }

        public ICollection<RequestSerial> RequestSerial { get; set; }
    }
}

