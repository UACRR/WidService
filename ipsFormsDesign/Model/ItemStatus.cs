using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ItemStatus : IItemStatus
    {
        public ItemStatus()
        {
            BrRegItem = new ObservableListSource<BrRegItem>();
            ItemStatusTr = new ObservableListSource<ItemStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<BrRegItem> BrRegItem { get; set; }
        public ObservableListSource<ItemStatusTr> ItemStatusTr { get; set; }
    }
}

