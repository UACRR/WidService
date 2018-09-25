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

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<DistribStatusTr> DistribStatusTr { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
    }
}
