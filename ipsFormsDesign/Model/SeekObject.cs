using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SeekObject : ISeekObject
    {
        public int id { get; set; }
        public int? codeI { get; set; }
        public int? objId { get; set; }
        public string name { get; set; }

        public SeekType codeINavigation { get; set; }
        public ObjectRight obj { get; set; }
    }
}

