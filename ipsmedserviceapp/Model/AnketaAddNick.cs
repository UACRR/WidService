using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaAddNick
    {
        public int AddId { get; set; }
        public int CustId { get; set; }
        public string NikName { get; set; }

        public RightHolder Cust { get; set; }
    }
}
