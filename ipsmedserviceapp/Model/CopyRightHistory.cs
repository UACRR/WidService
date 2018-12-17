using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CopyRightHistory
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public decimal? Rate { get; set; }

        public CopyRight Child { get; set; }
        public CopyRight Parent { get; set; }
    }
}
