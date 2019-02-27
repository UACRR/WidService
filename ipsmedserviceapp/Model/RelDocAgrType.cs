using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelDocAgrType
    {
        public int AgrType { get; set; }
        public int DocType { get; set; }

        public virtual AgreementType AgrTypeNavigation { get; set; }
        public virtual DocumentType DocTypeNavigation { get; set; }
    }
}
