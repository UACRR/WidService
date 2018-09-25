using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class relCounterDoc : IrelCounterDoc
    {
        public int cDocId { get; set; }
        public int counterId { get; set; }
        public int docType { get; set; }
        public int? licType { get; set; }

        public CounterNumber counter { get; set; }
        public DocumentType docTypeNavigation { get; set; }
        public AgrLicenseType licTypeNavigation { get; set; }
    }
}

