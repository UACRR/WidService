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

        public int custId { get; set; }
        public int version { get; set; }

        public Customer cust { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
    }
}

