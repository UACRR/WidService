using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MyCopyRightType
    {
        public int CustId { get; set; }
        public int CRtype { get; set; }

        public CopyrightType CRtypeNavigation { get; set; }
        public MyAnketa Cust { get; set; }
    }
}
