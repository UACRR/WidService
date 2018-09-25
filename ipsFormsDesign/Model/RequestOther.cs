using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestOther : IRequestOther
    {
        public int reqId { get; set; }
        public string useDesc { get; set; }

        public Request req { get; set; }
    }
}

