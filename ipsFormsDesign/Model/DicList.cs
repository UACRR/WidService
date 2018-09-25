using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DicList : IDicList
    {
        public int dicId { get; set; }
        public string dKind { get; set; }
        public int dCode { get; set; }
        public string dNameUk { get; set; }
        public string dNameRu { get; set; }
        public string dNameEn { get; set; }
    }
}

