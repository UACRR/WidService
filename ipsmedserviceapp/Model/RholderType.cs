using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RHolderType
    {
        public RHolderType()
        {
            RHolderTypeTr = new HashSet<RHolderTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<RHolderTypeTr> RHolderTypeTr { get; set; }
    }
}
