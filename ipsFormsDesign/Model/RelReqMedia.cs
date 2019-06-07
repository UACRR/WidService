using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelReqMedia : IRelReqMedia
    {
        public int UseMediaTypeCode { get; set; }
        public int ReqId { get; set; }

        public virtual Request Req { get; set; }
        public virtual UseMediaType UseMediaTypeCodeNavigation { get; set; }
    }
}

