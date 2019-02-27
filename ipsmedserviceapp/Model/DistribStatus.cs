using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DistribStatus
    {
        public DistribStatus()
        {
            DistribStatusTr = new HashSet<DistribStatusTr>();
            Distribution = new HashSet<Distribution>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DistribStatusTr> DistribStatusTr { get; set; }
        public virtual ICollection<Distribution> Distribution { get; set; }
    }
}
