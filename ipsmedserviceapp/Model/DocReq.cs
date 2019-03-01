using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DocReq
    {
        public int DocId { get; set; }
        public int ReqId { get; set; }

        public virtual Request Req { get; set; }
    }
}
