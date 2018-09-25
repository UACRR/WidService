using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SeekObject
    {
        public int id { get; set; }
        public int? codeI { get; set; }
        public int? objId { get; set; }
        public string name { get; set; }

        public SeekType codeINavigation { get; set; }
        public ObjectRight obj { get; set; }
    }
}
