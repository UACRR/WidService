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

        public int cRKindCode { get; set; }

        public CopyrightKind cRKindCodeNavigation { get; set; }
        public ObservableListSource<PortalObjectRights> PortalObjectRights { get; set; }
    }
}

