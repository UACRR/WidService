using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SysVersion
    {
        public int VersId { get; set; }
        public string VersCode { get; set; }
        public string VersName { get; set; }
        public DateTime? VersDate { get; set; }
    }
}
