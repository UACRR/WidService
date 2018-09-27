using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FixFile
    {
        public int FixId { get; set; }
        public int FileId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public Fixation Fix { get; set; }
    }
}
