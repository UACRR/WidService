using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class myCopyRightType
    {
        public int custId { get; set; }
        public int cRType { get; set; }

        public CopyrightType cRTypeNavigation { get; set; }
        public MyAnketa cust { get; set; }
    }
}
