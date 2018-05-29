using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PositionType : IPositionType
    {
        public PositionType()
        {
            PositionTypeTr = new HashSet<PositionTypeTr>();
            RelEmployee = new HashSet<RelEmployee>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<PositionTypeTr> PositionTypeTr { get; set; }
        public ICollection<RelEmployee> RelEmployee { get; set; }
    }
}

