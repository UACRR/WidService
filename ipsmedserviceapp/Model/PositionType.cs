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

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<PositionTypeTr> PositionTypeTr { get; set; }
        public ICollection<RelEmployee> RelEmployee { get; set; }
    }
}
