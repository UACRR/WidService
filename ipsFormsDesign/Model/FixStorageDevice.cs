using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FixStorageDevice : IFixStorageDevice
    {
        public int FixId { get; set; }
        public int StorageId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public decimal? Capacity { get; set; }

        public Fixation Fix { get; set; }
    }
}

