using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Document : IDocument
    {
        public Document()
        {
            DocReq = new HashSet<DocReq>();
        }

        public int DocId { get; set; }
        public int DocType { get; set; }
        public DateTime DocDate { get; set; }
        public string DocNumber { get; set; }
        public string DocFile { get; set; }
        public int? DocStatus { get; set; }
        public int? PeriodId { get; set; }

        public DocumentStatus DocStatusNavigation { get; set; }
        public DocumentType DocTypeNavigation { get; set; }
        public PaidPeriod Period { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<DocReq> DocReq { get; set; }
    }
}

