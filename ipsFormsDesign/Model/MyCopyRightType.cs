using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MyCopyRightType : IMyCopyRightType
    {
        public int CustId { get; set; }
        public int CRtype { get; set; }

        public virtual CopyrightType CRtypeNavigation { get; set; }
        public virtual MyAnketa Cust { get; set; }
    }
}

