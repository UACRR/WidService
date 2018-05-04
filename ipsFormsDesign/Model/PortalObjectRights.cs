using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PortalObjectRights
    {
        public int ObjId { get; set; }
        public int CRkindCode { get; set; }
        public int Enable { get; set; }

        public PortalSupportRights CRkindCodeNavigation { get; set; }
        public ObjectRight Obj { get; set; }
    }
}
