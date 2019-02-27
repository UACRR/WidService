using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MyCopyRightType
    {
        public int CustId { get; set; }
        public int CRtype { get; set; }

        public virtual CopyrightType CRtypeNavigation { get; set; }
        public virtual MyAnketa Cust { get; set; }
    }
}
