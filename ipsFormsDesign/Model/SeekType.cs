using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SeekType : ISeekType
    {
        public SeekType()
        {
            SeekObject = new HashSet<SeekObject>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<SeekObject> SeekObject { get; set; }
    }
}

