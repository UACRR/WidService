using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AlgorithmType
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
