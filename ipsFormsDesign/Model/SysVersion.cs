using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SysVersion : ISysVersion
    {
        public int VersId { get; set; }
        public string VersCode { get; set; }
        public string VersName { get; set; }
        public DateTime? VersDate { get; set; }
    }
}

