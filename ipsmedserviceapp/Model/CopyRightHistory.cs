using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CopyRightHistory
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public decimal? Rate { get; set; }

        public virtual CopyRight Child { get; set; }
        public virtual CopyRight Parent { get; set; }
    }
}
