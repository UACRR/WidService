using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            RelDocAgrType = new HashSet<RelDocAgrType>();
            relCounterDoc = new HashSet<relCounterDoc>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<RelDocAgrType> RelDocAgrType { get; set; }
        public ICollection<relCounterDoc> relCounterDoc { get; set; }
    }
}
