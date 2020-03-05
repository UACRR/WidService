using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PermitRoleTask : IPermitRoleTask
    {
        public int RoleCode { get; set; }
        public int TaskCode { get; set; }

        public virtual PermitRole RoleCodeNavigation { get; set; }
        public virtual PermitTask TaskCodeNavigation { get; set; }
    }
}

