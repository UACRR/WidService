using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FixStorageDevice : IFixStorageDevice
    {
        public int storageId { get; set; }
        public int fixId { get; set; }
        public string name { get; set; }
        public string serialNumber { get; set; }
        public decimal? capacity { get; set; }

        public Fixation fix { get; set; }
    }
}

