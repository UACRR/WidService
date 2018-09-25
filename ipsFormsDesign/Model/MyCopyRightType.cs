using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class myCopyRightType : ImyCopyRightType
    {
        public int custId { get; set; }
        public int cRType { get; set; }

        public CopyrightType cRTypeNavigation { get; set; }
        public MyAnketa cust { get; set; }
    }
}

