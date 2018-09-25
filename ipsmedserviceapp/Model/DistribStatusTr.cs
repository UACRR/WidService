using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DistribStatusTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public DistribStatus CodeINavigation { get; set; }
    }
}
