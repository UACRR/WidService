using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MonthNameTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public MonthName CodeINavigation { get; set; }
    }
}
