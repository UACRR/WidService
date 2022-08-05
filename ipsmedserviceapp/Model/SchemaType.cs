using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SchemaType
    {
        public int CodeI { get; set; }
        public string Name { get; set; }
        public short? IsMinAmount { get; set; }
        public short? IsRateAmount { get; set; }
    }
}
