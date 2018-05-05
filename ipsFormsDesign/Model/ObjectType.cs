using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ObjectType
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
