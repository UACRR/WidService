using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaStatusTr
    {
        public int AnkStatus { get; set; }
        public string Lang { get; set; }
        public string AnkStatusName { get; set; }

        public AnketaStatus AnkStatusNavigation { get; set; }
    }
}
