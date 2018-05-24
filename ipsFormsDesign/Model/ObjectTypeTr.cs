using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ObjectTypeTr : IObjectTypeTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }
        public int CategoryCode { get; set; }

        public ObjectType C { get; set; }
    }
}

