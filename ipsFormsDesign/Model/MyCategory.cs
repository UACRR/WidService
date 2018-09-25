using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MyCategory : IMyCategory
    {
        public int custId { get; set; }
        public int codeI { get; set; }

        public Category codeINavigation { get; set; }
        public MyAnketa cust { get; set; }
    }
}

