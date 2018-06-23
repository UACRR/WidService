using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PortalSupportRights : IPortalSupportRights
    {
        public PortalSupportRights()
        {
            PortalObjectRights = new ObservableListSource<PortalObjectRights>();
        }

        public int CRkindCode { get; set; }

        public CopyrightKind CRkindCodeNavigation { get; set; }
        public ObservableListSource<PortalObjectRights> PortalObjectRights { get; set; }
    }
}

