using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DicList : IDicList
    {
        public int DicId { get; set; }
        public string DKind { get; set; }
        public int DCode { get; set; }
        public string DNameUk { get; set; }
        public string DNameRu { get; set; }
        public string DNameEn { get; set; }
    }
}

