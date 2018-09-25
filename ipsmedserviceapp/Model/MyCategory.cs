using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MyCategory
    {
        public int custId { get; set; }
        public int codeI { get; set; }

        public Category codeINavigation { get; set; }
        public MyAnketa cust { get; set; }
    }
}
