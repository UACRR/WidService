using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Person : IPerson
    {
        public Person()
        {
            AnketaPerson = new HashSet<AnketaPerson>();
        }

        public int CustId { get; set; }
        public int Version { get; set; }

        public Customer Cust { get; set; }
        public ICollection<AnketaPerson> AnketaPerson { get; set; }
    }
}

