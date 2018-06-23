using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AnketaExternal : IAnketaExternal
    {
        public int CustId { get; set; }
        public string Name { get; set; }
        public string InterCode { get; set; }

        public Customer Cust { get; set; }
    }
}

