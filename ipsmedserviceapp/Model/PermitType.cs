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

        public bool codeB { get; set; }
        public string name { get; set; }

        public ICollection<PermitTypeTr> PermitTypeTr { get; set; }
    }
}
