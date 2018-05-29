using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ObjectType : IObjectType
    {
        public ObjectType()
        {
            ObjectRight = new HashSet<ObjectRight>();
            ObjectTypeTr = new HashSet<ObjectTypeTr>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<ObjectRight> ObjectRight { get; set; }
        public ICollection<ObjectTypeTr> ObjectTypeTr { get; set; }
    }
}

