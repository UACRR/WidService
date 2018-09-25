using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ReqTrade
    {
        public int TradeId { get; set; }
        public int ReqId { get; set; }
        public string R030 { get; set; }
        public decimal? CostRholder { get; set; }
        public DateTime? CreateDate { get; set; }
        public int RAgrId { get; set; }
        public int Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public decimal? CostClient { get; set; }
        public string TradeComment { get; set; }
        public int? CauseCode { get; set; }

        public CommentCause CauseCodeNavigation { get; set; }
        public ReqAgreement RAgr { get; set; }
        public Request Req { get; set; }
        public TradeStatus StatusNavigation { get; set; }
    }
}
