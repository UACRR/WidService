using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PositionType
    {
        public PositionType()
        {
            PositionTypeTr = new HashSet<PositionTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<PositionTypeTr> PositionTypeTr { get; set; }
    }
}
