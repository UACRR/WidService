using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SystemConstant
    {
        public SystemConstant()
        {
            SystemConstantTr = new HashSet<SystemConstantTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public decimal? Rate { get; set; }

        public ICollection<SystemConstantTr> SystemConstantTr { get; set; }
    }
}
