using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DocumentType : IDocumentType
    {
        public DocumentType()
        {
            RelDocAgrType = new ObservableListSource<RelDocAgrType>();
            relCounterDoc = new ObservableListSource<relCounterDoc>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<RelDocAgrType> RelDocAgrType { get; set; }
        public ObservableListSource<relCounterDoc> relCounterDoc { get; set; }
    }
}

