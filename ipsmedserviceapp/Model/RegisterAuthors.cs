using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterAuthors
    {
        public int regId { get; set; }
        public int regIItemId { get; set; }
        public int authId { get; set; }
        public int codeRole { get; set; }
        public string Name { get; set; }

        public CreativeRoleType codeRoleNavigation { get; set; }
    }
}
