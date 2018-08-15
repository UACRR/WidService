using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterAuthors : IRegisterAuthors
    {
        public int RegId { get; set; }
        public int RegIitemId { get; set; }
        public int AuthId { get; set; }
        public int CodeRole { get; set; }
        public string Name { get; set; }

        public CreativeRoleType CodeRoleNavigation { get; set; }
    }
}

