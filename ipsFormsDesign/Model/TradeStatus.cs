using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TradeStatus : ITradeStatus
    {
        public TradeStatus()
        {
            ReqTrade = new ObservableListSource<ReqTrade>();
        }

        public int StatusCode { get; set; }
        public string StatusNameUk { get; set; }
        public string StatusNameRu { get; set; }
        public string StatusNameEn { get; set; }

        public ObservableListSource<ReqTrade> ReqTrade { get; set; }
    }
}

