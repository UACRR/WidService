using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ResidentType
    {
        public ResidentType()
        {
            AnketaPerson = new HashSet<AnketaPerson>();
            ResidentTypeTr = new HashSet<ResidentTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<AnketaPerson> AnketaPerson { get; set; }
        public ICollection<ResidentTypeTr> ResidentTypeTr { get; set; }
    }
}
