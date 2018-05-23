using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DistribType
    {
        public DistribType()
        {
            DistribTypeTr = new HashSet<DistribTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<DistribTypeTr> DistribTypeTr { get; set; }
    }
}
