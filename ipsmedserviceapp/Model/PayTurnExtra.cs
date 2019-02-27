using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PayTurnExtra
    {
        public int Turnid { get; set; }
        public DateTime Datework { get; set; }
        public int? Custid { get; set; }
        public int? Payturntype { get; set; }
    }
}
