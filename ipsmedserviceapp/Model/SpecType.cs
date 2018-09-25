using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SpecType
    {
        public SpecType()
        {
            ObjectRight = new HashSet<ObjectRight>();
            SpecTypeTr = new HashSet<SpecTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<ObjectRight> ObjectRight { get; set; }
        public ICollection<SpecTypeTr> SpecTypeTr { get; set; }
    }
}
