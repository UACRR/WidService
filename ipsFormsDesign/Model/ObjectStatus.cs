using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ObjectStatus : IObjectStatus
    {
        public ObjectStatus()
        {
            ObjectRight = new ObservableListSource<ObjectRight>();
            ObjectStatusTr = new ObservableListSource<ObjectStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<ObjectRight> ObjectRight { get; set; }
        public virtual ObservableListSource<ObjectStatusTr> ObjectStatusTr { get; set; }
    }
}

