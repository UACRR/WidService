using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DocumentKind
    {
        public DocumentKind()
        {
            DocTemplate = new HashSet<DocTemplate>();
            Document = new HashSet<Document>();
            DocumentKindTr = new HashSet<DocumentKindTr>();
        }

        public int CodeI { get; set; }
        public int? CategoryCode { get; set; }
        public string Name { get; set; }
        public string DocMaker { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<DocTemplate> DocTemplate { get; set; }
        public ICollection<Document> Document { get; set; }
        public ICollection<DocumentKindTr> DocumentKindTr { get; set; }
    }
}
