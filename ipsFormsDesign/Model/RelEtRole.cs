using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelEtRole : IRelEtRole
    {
        public int RoleCode { get; set; }
        public int EtRoleCode { get; set; }

        public virtual EtRole EtRoleCodeNavigation { get; set; }
        public virtual CreativeRoleType RoleCodeNavigation { get; set; }
    }
}

