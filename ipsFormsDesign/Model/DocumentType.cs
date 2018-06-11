using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DocumentType : IDocumentType
    {
        public DocumentType()
        {
            Document = new HashSet<Document>();
            DocumentTypeTr = new HashSet<DocumentTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public string TemplNum { get; set; }
        public string TemplPath { get; set; }

        public ICollection<Document> Document { get; set; }
        public ICollection<DocumentTypeTr> DocumentTypeTr { get; set; }
    }
}

