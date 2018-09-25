using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaAddNick
    {
        public int addId { get; set; }
        public int custId { get; set; }
        public string nikName { get; set; }

        public RightHolder cust { get; set; }
    }
}
