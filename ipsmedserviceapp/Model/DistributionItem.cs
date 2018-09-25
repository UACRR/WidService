using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DistributionItem
    {
        public int DistId { get; set; }
        public int? RegId { get; set; }
        public int? RegIitemId { get; set; }
        public decimal? Amount { get; set; }
        public int? Status { get; set; }
        public int? RegIdBr { get; set; }
        public int? RegItemIdBr { get; set; }
        public int DistItemId { get; set; }
        public int? ObjId { get; set; }

        public Distribution Dist { get; set; }
        public ObjectRight Obj { get; set; }
    }
}
