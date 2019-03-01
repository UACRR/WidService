using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AlgorithmTypeTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public virtual AlgorithmType CodeINavigation { get; set; }
    }
}
