using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class UserRole : IUserRole
    {
        public int CustId { get; set; }
        public int RoleType { get; set; }
        public string UserId { get; set; }
        public int? Status { get; set; }

        public Customer Cust { get; set; }
        public UserRoleType RoleTypeNavigation { get; set; }
        public AspNetUsers User { get; set; }
    }
}

