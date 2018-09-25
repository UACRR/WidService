using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TableColumnTech
    {
        public decimal id { get; set; }
        public string cname { get; set; }
        public string tname { get; set; }
        public string dnameUk { get; set; }
        public string dnameRu { get; set; }
        public string dnameEn { get; set; }
        public short? typeTab { get; set; }
    }
}
