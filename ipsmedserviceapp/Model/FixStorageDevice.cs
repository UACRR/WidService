using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FixStorageDevice
    {
        public int FixId { get; set; }
        public int StorageId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public decimal? Capacity { get; set; }

        public virtual Fixation Fix { get; set; }
    }
}
