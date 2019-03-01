using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PermitTypeTr
    {
        public bool CodeB { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public virtual PermitType CodeBNavigation { get; set; }
    }
}
