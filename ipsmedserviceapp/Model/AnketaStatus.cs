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

        public int AnkStatus { get; set; }
        public string AnkStatusName { get; set; }

        public ICollection<AnketaStatusTr> AnketaStatusTr { get; set; }
    }
}
