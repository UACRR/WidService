using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelAdaptUseArea
    {
        public int ReqId { get; set; }
        public int UseAreaTypeCode { get; set; }

        public virtual RequestAdapt Req { get; set; }
        public virtual UseAreaType UseAreaTypeCodeNavigation { get; set; }
    }
}
