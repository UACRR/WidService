using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PermitTypeTr : IPermitTypeTr
    {
        public bool CodeB { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public virtual PermitType CodeBNavigation { get; set; }
    }
}

