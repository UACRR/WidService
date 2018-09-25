using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterExtra : IRegisterExtra
    {
        public int regExtraId { get; set; }
        public int regId { get; set; }
        public int regIItemId { get; set; }
        public int roleCode { get; set; }
        public string name { get; set; }

        public RegisterItem regI { get; set; }
        public CreativeRoleType roleCodeNavigation { get; set; }
    }
}

