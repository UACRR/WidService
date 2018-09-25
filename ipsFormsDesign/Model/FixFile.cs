using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FixFile : IFixFile
    {
        public int fileId { get; set; }
        public int? fixId { get; set; }
        public string name { get; set; }
        public string path { get; set; }

        public Fixation fix { get; set; }
    }
}

