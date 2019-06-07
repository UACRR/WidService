using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TableType : ITableType
    {
        public string TName { get; set; }
        public short? TType { get; set; }
    }
}

