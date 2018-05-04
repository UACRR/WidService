using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Document
    {
        public Document()
        {
            DocReq = new HashSet<DocReq>();
        }

        public int DocId { get; set; }
        public int DocTypeCode { get; set; }
        public DateTime DocDate { get; set; }
        public string DocNumber { get; set; }
        public string DocFile { get; set; }
        public int? DocStatus { get; set; }

        public DocumentKind DocTypeCodeNavigation { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<DocReq> DocReq { get; set; }
    }
}
