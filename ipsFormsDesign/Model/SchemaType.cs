using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SchemaType : ISchemaType
    {
        public int CodeI { get; set; }
        public string Name { get; set; }
        public short? IsMinAmount { get; set; }
        public short? IsRateAmount { get; set; }
    }
}

