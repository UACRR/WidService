using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterAuthors
    {
        public int RegId { get; set; }
        public int RegIitemId { get; set; }
        public int AuthId { get; set; }
        public int CodeRole { get; set; }
        public string Name { get; set; }

        public CreativeRoleType CodeRoleNavigation { get; set; }
    }
}
