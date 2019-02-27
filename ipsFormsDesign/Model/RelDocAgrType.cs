using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelDocAgrType : IRelDocAgrType
    {
        public int AgrType { get; set; }
        public int DocType { get; set; }

        public virtual AgreementType AgrTypeNavigation { get; set; }
        public virtual DocumentType DocTypeNavigation { get; set; }
    }
}

