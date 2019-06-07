using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RholderTypeTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public virtual RholderType CodeINavigation { get; set; }
    }
}
