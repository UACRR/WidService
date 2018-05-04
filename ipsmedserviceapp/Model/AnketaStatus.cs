using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaStatus
    {
        public AnketaStatus()
        {
            AnketaCompany = new HashSet<AnketaCompany>();
            AnketaPerson = new HashSet<AnketaPerson>();
            AnketaStatusTr = new HashSet<AnketaStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<AnketaCompany> AnketaCompany { get; set; }
        public ICollection<AnketaPerson> AnketaPerson { get; set; }
        public ICollection<AnketaStatusTr> AnketaStatusTr { get; set; }
    }
}
