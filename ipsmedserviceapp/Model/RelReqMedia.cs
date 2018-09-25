using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelReqMedia
    {
        public int useMediaTypeCode { get; set; }
        public int reqId { get; set; }

        public Request req { get; set; }
        public UseMediaType useMediaTypeCodeNavigation { get; set; }
    }
}
