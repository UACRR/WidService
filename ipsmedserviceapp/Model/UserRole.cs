using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UserRole
    {
        public int CustId { get; set; }
        public int RoleType { get; set; }
        public string UserId { get; set; }
        public int? Status { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual UserRoleType RoleTypeNavigation { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
