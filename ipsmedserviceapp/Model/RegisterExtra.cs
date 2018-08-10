using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterExtra
    {
        public int RegExtraId { get; set; }
        public int RegId { get; set; }
        public int RegIitemId { get; set; }
        public int RoleCode { get; set; }
        public string Name { get; set; }

        public RegisterItem RegI { get; set; }
        public CreativeRoleType RoleCodeNavigation { get; set; }
    }
}
