using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ObjectStatus
    {
        public ObjectStatus()
        {
            ObjectRight = new HashSet<ObjectRight>();
            ObjectStatusTr = new HashSet<ObjectStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ObjectRight> ObjectRight { get; set; }
        public virtual ICollection<ObjectStatusTr> ObjectStatusTr { get; set; }
    }
}
