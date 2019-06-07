using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterExtra : IRegisterExtra
    {
        public int RegExtraId { get; set; }
        public int RegId { get; set; }
        public int RegIitemId { get; set; }
        public int RoleCode { get; set; }
        public string Name { get; set; }

        public virtual RegisterItem RegI { get; set; }
        public virtual CreativeRoleType RoleCodeNavigation { get; set; }
    }
}

