using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DocumentStatus : IDocumentStatus
    {
        public DocumentStatus()
        {
            Document = new ObservableListSource<Document>();
            DocumentStatusTr = new ObservableListSource<DocumentStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<Document> Document { get; set; }
        public ObservableListSource<DocumentStatusTr> DocumentStatusTr { get; set; }
    }
}

