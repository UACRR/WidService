using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MyCategory
    {
        public int CustId { get; set; }
        public int CodeI { get; set; }

        public virtual Category CodeINavigation { get; set; }
        public virtual MyAnketa Cust { get; set; }
    }
}
