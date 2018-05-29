using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DocReq : IDocReq
    {
        public int DocId { get; set; }
        public int ReqId { get; set; }

        public Document Doc { get; set; }
        public Request Req { get; set; }
    }
}

