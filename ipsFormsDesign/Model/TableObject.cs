using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TableObject : ITableObject
    {
        public decimal id { get; set; }
        public string lang { get; set; }
        public string cName { get; set; }
        public string dText { get; set; }
        public string hText { get; set; }
    }
}

