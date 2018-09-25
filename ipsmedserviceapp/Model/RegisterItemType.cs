using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterItemType
    {
        public RegisterItemType()
        {
            RegisterItem = new HashSet<RegisterItem>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<RegisterItem> RegisterItem { get; set; }
    }
}
