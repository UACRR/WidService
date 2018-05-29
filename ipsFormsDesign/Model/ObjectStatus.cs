using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ObjectStatus : IObjectStatus
    {
        public ObjectStatus()
        {
            ObjectRight = new HashSet<ObjectRight>();
            ObjectStatusTr = new HashSet<ObjectStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<ObjectRight> ObjectRight { get; set; }
        public ICollection<ObjectStatusTr> ObjectStatusTr { get; set; }
    }
}

