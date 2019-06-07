using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DistributionItem : IDistributionItem
    {
        public DistributionItem()
        {
            RegisterCount = new ObservableListSource<RegisterCount>();
        }

        public int DistId { get; set; }
        public int? RegId { get; set; }
        public int? RegIitemId { get; set; }
        public decimal? Amount { get; set; }
        public int? Status { get; set; }
        public int? RegIdBr { get; set; }
        public int? RegItemIdBr { get; set; }
        public int DistItemId { get; set; }
        public int? ObjId { get; set; }

        public virtual Distribution Dist { get; set; }
        public virtual ObjectRight Obj { get; set; }
        public virtual ObservableListSource<RegisterCount> RegisterCount { get; set; }
    }
}

