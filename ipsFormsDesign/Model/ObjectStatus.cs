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

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<ObjectRight> ObjectRight { get; set; }
        public ObservableListSource<ObjectStatusTr> ObjectStatusTr { get; set; }
    }
}

