using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MyCategory : IMyCategory
    {
        public int CustId { get; set; }
        public int CodeI { get; set; }

        public Category CodeINavigation { get; set; }
        public MyAnketa Cust { get; set; }
    }
}

