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

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<DistribTypeTr> DistribTypeTr { get; set; }
    }
}
