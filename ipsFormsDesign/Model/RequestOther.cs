using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestOther
    {
        public int ReqId { get; set; }
        public string UseDesc { get; set; }

        public Request Req { get; set; }
    }
}
