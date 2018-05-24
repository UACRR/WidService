using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PortalSupportRights : IPortalSupportRights
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

