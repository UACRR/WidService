using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DocumentKind : IDocumentKind
    {
        public DocumentKind()
        {
            DocumentKindTr = new ObservableListSource<DocumentKindTr>();
        }

        public int CodeI { get; set; }
        public int? CategoryCode { get; set; }
        public string Name { get; set; }
        public string DocMaker { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<DocumentKindTr> DocumentKindTr { get; set; }
    }
}

