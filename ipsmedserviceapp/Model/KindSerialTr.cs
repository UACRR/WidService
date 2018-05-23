using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class KindSerialTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public KindSerial CodeINavigation { get; set; }
    }
}
