using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ObjectStatus
    {
        public ObjectStatus()
        {
            ObjectStatusTr = new HashSet<ObjectStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<ObjectStatusTr> ObjectStatusTr { get; set; }
    }
}
