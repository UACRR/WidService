using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DistribType : IDistribType
    {
        public DistribType()
        {
            DistribTypeTr = new ObservableListSource<DistribTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<DistribTypeTr> DistribTypeTr { get; set; }
    }
}

