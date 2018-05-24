using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SeekObject : ISeekObject
    {
        public int Id { get; set; }
        public int? CodeI { get; set; }
        public int? ObjId { get; set; }
        public string Name { get; set; }

        public SeekType CodeINavigation { get; set; }
        public ObjectRight Obj { get; set; }
    }
}

