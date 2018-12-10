using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CopyRightHistory : ICopyRightHistory
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public decimal? Rate { get; set; }

        public CopyRight Child { get; set; }
        public CopyRight Parent { get; set; }
    }
}

