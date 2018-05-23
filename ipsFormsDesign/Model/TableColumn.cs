using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TableColumn : ITableColumn
    {
        public decimal Id { get; set; }
        public string Lang { get; set; }
        public string CName { get; set; }
        public string TName { get; set; }
        public string DText { get; set; }
        public string HText { get; set; }
    }
}

