using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AnketaAddNick : IAnketaAddNick
    {
        public int AddId { get; set; }
        public int CustId { get; set; }
        public string NikName { get; set; }

        public RightHolder Cust { get; set; }
    }
}

