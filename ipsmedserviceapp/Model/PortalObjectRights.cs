using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PortalObjectRights
    {
        public int objId { get; set; }
        public int cRKindCode { get; set; }
        public int enable { get; set; }

        public PortalSupportRights cRKindCodeNavigation { get; set; }
        public ObjectRight obj { get; set; }
    }
}
