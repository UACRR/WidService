using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PortalObjectRights : IPortalObjectRights
    {
        public int objId { get; set; }
        public int cRKindCode { get; set; }
        public int enable { get; set; }

        public PortalSupportRights cRKindCodeNavigation { get; set; }
        public ObjectRight obj { get; set; }
    }
}

