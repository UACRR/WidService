using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DocReq : IDocReq
    {
        public int DocId { get; set; }
        public int ReqId { get; set; }

        public virtual Request Req { get; set; }
    }
}

