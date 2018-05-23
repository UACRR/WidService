using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TableType : ITableType
    {
        public string TName { get; set; }
        public short? TType { get; set; }
    }
}

