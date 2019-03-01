using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PortalObjectRights
    {
        public int ObjId { get; set; }
        public int CRkindCode { get; set; }
        public int Enable { get; set; }

        public virtual PortalSupportRights CRkindCodeNavigation { get; set; }
        public virtual ObjectRight Obj { get; set; }
    }
}
