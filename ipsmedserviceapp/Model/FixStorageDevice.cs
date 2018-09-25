using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FixStorageDevice
    {
        public int StorageId { get; set; }
        public int FixId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public decimal? Capacity { get; set; }

        public Fixation Fix { get; set; }
    }
}
