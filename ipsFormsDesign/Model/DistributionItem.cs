using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DistributionItem : IDistributionItem
    {
        public int distId { get; set; }
        public int? regId { get; set; }
        public int? regIItemId { get; set; }
        public decimal? amount { get; set; }
        public int? status { get; set; }
        public int? regIdBr { get; set; }
        public int? regItemIdBr { get; set; }
        public int distItemId { get; set; }
        public int? objId { get; set; }

        public Distribution dist { get; set; }
        public ObjectRight obj { get; set; }
    }
}

