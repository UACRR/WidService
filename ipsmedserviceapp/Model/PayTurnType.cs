using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PayTurnType
    {
        public int Codei { get; set; }
        public string Name { get; set; }
        public int? BalsDbt { get; set; }
        public int? BalsCrdt { get; set; }
    }
}
