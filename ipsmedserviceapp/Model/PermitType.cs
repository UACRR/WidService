using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PermitType
    {
        public PermitType()
        {
            PermitTypeTr = new HashSet<PermitTypeTr>();
        }

        public bool CodeB { get; set; }
        public string Name { get; set; }

        public ICollection<PermitTypeTr> PermitTypeTr { get; set; }
    }
}
