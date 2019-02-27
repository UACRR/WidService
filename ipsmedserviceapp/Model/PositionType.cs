using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PositionType
    {
        public PositionType()
        {
            PositionTypeTr = new HashSet<PositionTypeTr>();
            RelEmployee = new HashSet<RelEmployee>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PositionTypeTr> PositionTypeTr { get; set; }
        public virtual ICollection<RelEmployee> RelEmployee { get; set; }
    }
}
