using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            DocumentTypeTr = new HashSet<DocumentTypeTr>();
            RelCounterDoc = new HashSet<RelCounterDoc>();
            RelDocAgrType = new HashSet<RelDocAgrType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DocumentTypeTr> DocumentTypeTr { get; set; }
        public virtual ICollection<RelCounterDoc> RelCounterDoc { get; set; }
        public virtual ICollection<RelDocAgrType> RelDocAgrType { get; set; }
    }
}
