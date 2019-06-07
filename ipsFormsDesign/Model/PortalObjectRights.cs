using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PortalObjectRights : IPortalObjectRights
    {
        public int ObjId { get; set; }
        public int CRkindCode { get; set; }
        public int Enable { get; set; }

        public virtual PortalSupportRights CRkindCodeNavigation { get; set; }
        public virtual ObjectRight Obj { get; set; }
    }
}

