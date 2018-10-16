using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FixFile : IFixFile
    {
        public int FixId { get; set; }
        public int FileId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public Fixation Fix { get; set; }
    }
}

