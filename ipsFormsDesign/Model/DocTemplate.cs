using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DocTemplate : IDocTemplate
    {
        public int TemplId { get; set; }
        public int DocTypeCode { get; set; }
        public int? ReqType { get; set; }
        public string TemplName { get; set; }
        public string TemplPath { get; set; }

        public DocumentKind DocTypeCodeNavigation { get; set; }
        public RequestType ReqTypeNavigation { get; set; }
    }
}

