using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class WorkTypeTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public virtual WorkType CodeINavigation { get; set; }
    }
}
