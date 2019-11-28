using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Person : IPerson
    {
        public Person()
        {
            AnketaPerson = new ObservableListSource<AnketaPerson>();
        }

        public int CustId { get; set; }
        public int Version { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
    }
}

