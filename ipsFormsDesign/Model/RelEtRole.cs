using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class relEtRole : IrelEtRole
    {
        public int roleCode { get; set; }
        public int etRoleCode { get; set; }

        public EtRole etRoleCodeNavigation { get; set; }
        public CreativeRoleType roleCodeNavigation { get; set; }
    }
}

