using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelAdaptUseArea
    {
        public int reqId { get; set; }
        public int useAreaTypeCode { get; set; }

        public RequestAdapt req { get; set; }
        public UseAreaType useAreaTypeCodeNavigation { get; set; }
    }
}
