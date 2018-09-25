using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TradeStatus
    {
        public TradeStatus()
        {
            ReqTrade = new HashSet<ReqTrade>();
        }

        public int statusCode { get; set; }
        public string statusNameUk { get; set; }
        public string statusNameRu { get; set; }
        public string statusNameEn { get; set; }

        public ICollection<ReqTrade> ReqTrade { get; set; }
    }
}
