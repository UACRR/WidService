using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelDocAgrType
    {
        public int AgrType { get; set; }
        public int DocType { get; set; }

        public AgreementType AgrTypeNavigation { get; set; }
        public DocumentType DocTypeNavigation { get; set; }
    }
}
