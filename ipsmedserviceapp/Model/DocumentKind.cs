using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DocumentKind
    {
        public DocumentKind()
        {
            DocumentKindTr = new HashSet<DocumentKindTr>();
        }

        public int CodeI { get; set; }
        public int? CategoryCode { get; set; }
        public string Name { get; set; }
        public string DocMaker { get; set; }

        public ICollection<DocumentKindTr> DocumentKindTr { get; set; }
    }
}
