using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PeriodStatusTr : IPeriodStatusTr
    {
        public int CodeI { get; set; }
        public string Name { get; set; }
        public string Lang { get; set; }

        public PeriodStatus CodeINavigation { get; set; }
    }
}

