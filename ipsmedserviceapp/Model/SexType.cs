using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SexType
    {
        public SexType()
        {
            AnketaPerson = new HashSet<AnketaPerson>();
            SexTypeTr = new HashSet<SexTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<AnketaPerson> AnketaPerson { get; set; }
        public ICollection<SexTypeTr> SexTypeTr { get; set; }
    }
}
