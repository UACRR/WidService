using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelReqMedia : IRelReqMedia
    {
        public int useMediaTypeCode { get; set; }
        public int reqId { get; set; }

        public Request req { get; set; }
        public UseMediaType useMediaTypeCodeNavigation { get; set; }
    }
}

