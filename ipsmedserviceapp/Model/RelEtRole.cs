using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelEtRole
    {
        public int RoleCode { get; set; }
        public int EtRoleCode { get; set; }

        public EtRole EtRoleCodeNavigation { get; set; }
        public CreativeRoleType RoleCodeNavigation { get; set; }
    }
}
