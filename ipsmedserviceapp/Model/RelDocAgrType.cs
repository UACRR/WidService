using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelDocAgrType
    {
        public int agrType { get; set; }
        public int docType { get; set; }

        public AgreementType agrTypeNavigation { get; set; }
        public DocumentType docTypeNavigation { get; set; }
    }
}
