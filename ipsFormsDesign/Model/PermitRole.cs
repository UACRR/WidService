using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PermitRole : IPermitRole
    {
        public PermitRole()
        {
            PermitRoleTask = new ObservableListSource<PermitRoleTask>();
            PermitRoleTr = new ObservableListSource<PermitRoleTr>();
            PermitUserRole = new ObservableListSource<PermitUserRole>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<PermitRoleTask> PermitRoleTask { get; set; }
        public virtual ObservableListSource<PermitRoleTr> PermitRoleTr { get; set; }
        public virtual ObservableListSource<PermitUserRole> PermitUserRole { get; set; }
    }
}

