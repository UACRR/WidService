using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PayTurnExtra : IPayTurnExtra
    {
        public int Turnid { get; set; }
        public DateTime Datework { get; set; }
        public int? Custid { get; set; }
        public int? Payturntype { get; set; }
    }
}

