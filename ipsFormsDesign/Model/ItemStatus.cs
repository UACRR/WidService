using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ItemStatus : IItemStatus
    {
        public ItemStatus()
        {
            BrRegItem = new HashSet<BrRegItem>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<BrRegItem> BrRegItem { get; set; }
    }
}

