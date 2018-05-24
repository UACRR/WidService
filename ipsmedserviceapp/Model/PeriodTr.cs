using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PeriodTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }
        public string NameR { get; set; }

        public Period CodeINavigation { get; set; }
    }
}
