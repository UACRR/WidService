using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DistribStatus
    {
        public DistribStatus()
        {
            Distribution = new HashSet<Distribution>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<Distribution> Distribution { get; set; }
    }
}
