using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PermitRoleTask
    {
        public int RoleCode { get; set; }
        public int TaskCode { get; set; }

        public virtual PermitRole RoleCodeNavigation { get; set; }
        public virtual PermitTask TaskCodeNavigation { get; set; }
    }
}
