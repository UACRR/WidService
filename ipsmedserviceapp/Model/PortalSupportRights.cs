using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PortalSupportRights
    {
        public PortalSupportRights()
        {
            PortalObjectRights = new HashSet<PortalObjectRights>();
        }

        public int cRKindCode { get; set; }

        public CopyrightKind cRKindCodeNavigation { get; set; }
        public ICollection<PortalObjectRights> PortalObjectRights { get; set; }
    }
}
