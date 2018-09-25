using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PerformTypeTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public PerformType CodeINavigation { get; set; }
    }
}
