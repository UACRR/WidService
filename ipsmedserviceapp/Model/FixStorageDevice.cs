using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FixStorageDevice
    {
        public int storageId { get; set; }
        public int fixId { get; set; }
        public string name { get; set; }
        public string serialNumber { get; set; }
        public decimal? capacity { get; set; }

        public Fixation fix { get; set; }
    }
}
