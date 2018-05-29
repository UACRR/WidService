using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SpecType : ISpecType
    {
        public SpecType()
        {
            ObjectRight = new HashSet<ObjectRight>();
            SpecTypeTr = new HashSet<SpecTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<ObjectRight> ObjectRight { get; set; }
        public ICollection<SpecTypeTr> SpecTypeTr { get; set; }
    }
}

