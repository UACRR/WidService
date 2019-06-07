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

        public virtual CopyrightKind CRkindCodeNavigation { get; set; }
        public virtual ICollection<PortalObjectRights> PortalObjectRights { get; set; }
    }
}
