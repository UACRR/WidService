using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TableType : ITableType
    {
        public string tName { get; set; }
        public short? tType { get; set; }
    }
}

