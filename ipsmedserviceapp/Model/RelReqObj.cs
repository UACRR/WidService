using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelReqObj
    {
        public int CategoryCode { get; set; }
        public int ReqType { get; set; }
        public int KindGroupId { get; set; }
        public int? CrkindCode { get; set; }

        public virtual RequestType ReqTypeNavigation { get; set; }
    }
}
