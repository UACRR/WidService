using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AnketaAddNick : IAnketaAddNick
    {
        public int addId { get; set; }
        public int custId { get; set; }
        public string nikName { get; set; }

        public RightHolder cust { get; set; }
    }
}

