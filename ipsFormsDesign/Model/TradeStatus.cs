using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TradeStatus : ITradeStatus
    {
        public TradeStatus()
        {
            ReqTrade = new HashSet<ReqTrade>();
        }

        public int StatusCode { get; set; }
        public string StatusNameUk { get; set; }
        public string StatusNameRu { get; set; }
        public string StatusNameEn { get; set; }

        public ICollection<ReqTrade> ReqTrade { get; set; }
    }
}

