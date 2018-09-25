using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterAuthors : IRegisterAuthors
    {
        public int regId { get; set; }
        public int regIItemId { get; set; }
        public int authId { get; set; }
        public int codeRole { get; set; }
        public string Name { get; set; }

        public CreativeRoleType codeRoleNavigation { get; set; }
    }
}

