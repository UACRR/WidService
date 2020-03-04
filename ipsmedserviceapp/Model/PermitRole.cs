using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PermitRole
    {
        public PermitRole()
        {
            PermitRoleTask = new HashSet<PermitRoleTask>();
            PermitRoleTr = new HashSet<PermitRoleTr>();
            PermitUserRole = new HashSet<PermitUserRole>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PermitRoleTask> PermitRoleTask { get; set; }
        public virtual ICollection<PermitRoleTr> PermitRoleTr { get; set; }
        public virtual ICollection<PermitUserRole> PermitUserRole { get; set; }
    }
}
