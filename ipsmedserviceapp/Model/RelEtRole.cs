using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelEtRole
    {
        public int RoleCode { get; set; }
        public int EtRoleCode { get; set; }

        public virtual EtRole EtRoleCodeNavigation { get; set; }
        public virtual CreativeRoleType RoleCodeNavigation { get; set; }
    }
}
