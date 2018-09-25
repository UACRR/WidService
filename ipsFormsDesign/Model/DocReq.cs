using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DocReq : IDocReq
    {
        public int docId { get; set; }
        public int reqId { get; set; }

        public Request req { get; set; }
    }
}

