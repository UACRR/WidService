using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AlgorithmType : IAlgorithmType
    {
        public AlgorithmType()
        {
            AlgorithmTypeTr = new ObservableListSource<AlgorithmTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<AlgorithmTypeTr> AlgorithmTypeTr { get; set; }
    }
}

