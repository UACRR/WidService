using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class userRole : IuserRole
    {
        public int custId { get; set; }
        public int roleType { get; set; }
        public string userId { get; set; }
        public int? status { get; set; }

        public Customer cust { get; set; }
        public UserRoleType roleTypeNavigation { get; set; }
        public AspNetUsers user { get; set; }
    }
}

