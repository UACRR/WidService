using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DocumentStatus : IDocumentStatus
    {
        public DocumentStatus()
        {
            Document = new HashSet<Document>();
            DocumentStatusTr = new HashSet<DocumentStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<Document> Document { get; set; }
        public ICollection<DocumentStatusTr> DocumentStatusTr { get; set; }
    }
}

