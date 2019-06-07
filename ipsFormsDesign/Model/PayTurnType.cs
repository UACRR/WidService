using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PayTurnType : IPayTurnType
    {
        public int Codei { get; set; }
        public string Name { get; set; }
        public int? BalsDbt { get; set; }
        public int? BalsCrdt { get; set; }
    }
}

