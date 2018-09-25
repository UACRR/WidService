using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UsesTypeTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public UsesType CodeINavigation { get; set; }
    }
}
