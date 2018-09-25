using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelDocAgrType : IRelDocAgrType
    {
        public int agrType { get; set; }
        public int docType { get; set; }

        public AgreementType agrTypeNavigation { get; set; }
        public DocumentType docTypeNavigation { get; set; }
    }
}

