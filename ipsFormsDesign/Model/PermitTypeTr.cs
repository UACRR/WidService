using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PermitTypeTr : IPermitTypeTr
    {
        public bool codeB { get; set; }
        public string lang { get; set; }
        public string name { get; set; }

        public PermitType codeBNavigation { get; set; }
    }
}

