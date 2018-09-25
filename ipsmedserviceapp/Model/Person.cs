using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Person
    {
        public Person()
        {
            AnketaPerson = new HashSet<AnketaPerson>();
        }

        public int custId { get; set; }
        public int version { get; set; }

        [JsonIgnore]
        public Customer cust { get; set; }
        public ICollection<AnketaPerson> AnketaPerson { get; set; }
    }
}

