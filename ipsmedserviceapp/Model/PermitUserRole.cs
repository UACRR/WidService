using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PermitUserRole
    {
        public int UserCode { get; set; }
        public int RoleCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsWrite { get; set; }

        public virtual PermitRole RoleCodeNavigation { get; set; }
        public virtual PermitUser UserCodeNavigation { get; set; }
    }
}
