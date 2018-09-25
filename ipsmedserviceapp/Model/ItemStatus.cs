using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ItemStatus
    {
        public ItemStatus()
        {
            BrRegItem = new HashSet<BrRegItem>();
            ItemStatusTr = new HashSet<ItemStatusTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<BrRegItem> BrRegItem { get; set; }
        public ICollection<ItemStatusTr> ItemStatusTr { get; set; }
    }
}
