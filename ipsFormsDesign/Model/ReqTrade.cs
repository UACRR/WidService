using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ReqTrade : IReqTrade
    {
        public int tradeId { get; set; }
        public int reqId { get; set; }
        public string r030 { get; set; }
        public decimal? costRHolder { get; set; }
        public DateTime? createDate { get; set; }
        public int rAgrId { get; set; }
        public int status { get; set; }
        public DateTime? statusDate { get; set; }
        public DateTime? modifyDate { get; set; }
        public decimal? costClient { get; set; }
        public string tradeComment { get; set; }
        public int? causeCode { get; set; }

        public CommentCause causeCodeNavigation { get; set; }
        public ReqAgreement rAgr { get; set; }
        public Request req { get; set; }
        public TradeStatus statusNavigation { get; set; }
    }
}

