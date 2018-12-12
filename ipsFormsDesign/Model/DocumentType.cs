using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DocumentType : IDocumentType
    {
        public DocumentType()
        {
            DocumentTypeTr = new ObservableListSource<DocumentTypeTr>();
            RelCounterDoc = new ObservableListSource<RelCounterDoc>();
            RelDocAgrType = new ObservableListSource<RelDocAgrType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<DocumentTypeTr> DocumentTypeTr { get; set; }
        public ObservableListSource<RelCounterDoc> RelCounterDoc { get; set; }
        public ObservableListSource<RelDocAgrType> RelDocAgrType { get; set; }
    }
}

