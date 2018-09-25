using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class KindCompositionTr : IKindCompositionTr
    {
        public int codeI { get; set; }
        public string lang { get; set; }
        public string name { get; set; }

        public KindComposition codeINavigation { get; set; }
    }
}

