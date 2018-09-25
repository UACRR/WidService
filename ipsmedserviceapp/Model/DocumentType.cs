using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            RelCounterDoc = new HashSet<RelCounterDoc>();
            RelDocAgrType = new HashSet<RelDocAgrType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<RelCounterDoc> RelCounterDoc { get; set; }
        public ICollection<RelDocAgrType> RelDocAgrType { get; set; }
    }
}
