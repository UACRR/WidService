using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class relEtRole
    {
        public int roleCode { get; set; }
        public int etRoleCode { get; set; }

        public EtRole etRoleCodeNavigation { get; set; }
        public CreativeRoleType roleCodeNavigation { get; set; }
    }
}
