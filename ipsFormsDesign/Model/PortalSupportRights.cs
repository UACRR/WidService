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

        public int CRkindCode { get; set; }

        public CopyrightKind CRkindCodeNavigation { get; set; }
        public ICollection<PortalObjectRights> PortalObjectRights { get; set; }
    }
}
