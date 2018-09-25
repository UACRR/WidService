using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelDocAgrType : IRelDocAgrType
    {
        public int AgrType { get; set; }
        public int DocType { get; set; }

        public AgreementType AgrTypeNavigation { get; set; }
        public DocumentType DocTypeNavigation { get; set; }
    }
}

