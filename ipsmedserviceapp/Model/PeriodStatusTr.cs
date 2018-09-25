using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PeriodStatusTr
    {
        public int codeI { get; set; }
        public string name { get; set; }
        public string lang { get; set; }

        public PeriodStatus codeINavigation { get; set; }
    }
}
