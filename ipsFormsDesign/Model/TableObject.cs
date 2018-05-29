using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TableObject : ITableObject
    {
        public decimal Id { get; set; }
        public string Lang { get; set; }
        public string CName { get; set; }
        public string DText { get; set; }
        public string HText { get; set; }
    }
}

