using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DistribStatus : IDistribStatus
    {
        public DistribStatus()
        {
            DistribStatusTr = new ObservableListSource<DistribStatusTr>();
            Distribution = new ObservableListSource<Distribution>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<DistribStatusTr> DistribStatusTr { get; set; }
        public ObservableListSource<Distribution> Distribution { get; set; }
    }
}

