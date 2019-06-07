using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ItemStatusTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public virtual ItemStatus CodeINavigation { get; set; }
    }
}
