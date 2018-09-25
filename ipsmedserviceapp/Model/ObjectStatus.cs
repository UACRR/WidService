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

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<ObjectRight> ObjectRight { get; set; }
        public ICollection<ObjectStatusTr> ObjectStatusTr { get; set; }
    }
}
