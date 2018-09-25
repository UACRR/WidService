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

        public int statusCode { get; set; }
        public string statusNameUk { get; set; }
        public string statusNameRu { get; set; }
        public string statusNameEn { get; set; }

        public ObservableListSource<ReqTrade> ReqTrade { get; set; }
    }
}

