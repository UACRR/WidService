using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MyCategory
    {
        public int CustId { get; set; }
        public int CodeI { get; set; }

        public Category CodeINavigation { get; set; }
        public MyAnketa Cust { get; set; }
    }
}
