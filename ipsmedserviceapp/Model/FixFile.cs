using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FixFile
    {
        public int fileId { get; set; }
        public int? fixId { get; set; }
        public string name { get; set; }
        public string path { get; set; }

        public Fixation fix { get; set; }
    }
}
