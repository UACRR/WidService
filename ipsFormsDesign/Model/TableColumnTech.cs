using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TableColumnTech : ITableColumnTech
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

