using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TableColumnTech : ITableColumnTech
    {
        public decimal Id { get; set; }
        public string Cname { get; set; }
        public string Tname { get; set; }
        public string DnameUk { get; set; }
        public string DnameRu { get; set; }
        public string DnameEn { get; set; }
        public short? TypeTab { get; set; }
    }
}

