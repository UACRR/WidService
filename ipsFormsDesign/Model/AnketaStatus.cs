using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaStatus
    {
        public AnketaStatus()
        {
            AnketaStatusTr = new HashSet<AnketaStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<AnketaStatusTr> AnketaStatusTr { get; set; }
    }
}
