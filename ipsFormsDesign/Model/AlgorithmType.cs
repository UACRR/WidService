using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AlgorithmType : IAlgorithmType
    {
        public AlgorithmType()
        {
            AlgorithmTypeTr = new HashSet<AlgorithmTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<AlgorithmTypeTr> AlgorithmTypeTr { get; set; }
    }
}

