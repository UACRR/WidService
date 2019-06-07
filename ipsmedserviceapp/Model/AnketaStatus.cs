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

        public virtual ICollection<AnketaCompany> AnketaCompany { get; set; }
        public virtual ICollection<AnketaPerson> AnketaPerson { get; set; }
        public virtual ICollection<AnketaStatusTr> AnketaStatusTr { get; set; }
    }
}
