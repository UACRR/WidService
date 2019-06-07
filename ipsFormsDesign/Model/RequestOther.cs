using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestOther : IRequestOther
    {
        public int ReqId { get; set; }
        public string UseDesc { get; set; }

        public virtual Request Req { get; set; }
    }
}

