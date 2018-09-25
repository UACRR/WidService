using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelReqObj
    {
        public int categoryCode { get; set; }
        public int reqType { get; set; }
        public int kindGroupId { get; set; }
        public int? CRKindCode { get; set; }

        public RequestType reqTypeNavigation { get; set; }
    }
}
