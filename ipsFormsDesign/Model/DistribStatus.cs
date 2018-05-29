using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DistribStatus : IDistribStatus
    {
        public DistribStatus()
        {
            DistribStatusTr = new HashSet<DistribStatusTr>();
            Distribution = new HashSet<Distribution>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<DistribStatusTr> DistribStatusTr { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
    }
}

