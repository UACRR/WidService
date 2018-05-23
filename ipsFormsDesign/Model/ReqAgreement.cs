using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ReqAgreement : IReqAgreement
    {
        public ReqAgreement()
        {
            ReqTrade = new HashSet<ReqTrade>();
        }

        public int RAgrId { get; set; }
        public int CustId { get; set; }
        public int? CustIdRh { get; set; }
        public int? ReqId { get; set; }
        public string R030 { get; set; }
        public decimal? Amount { get; set; }
        public decimal? CostOffer { get; set; }
        public int Status { get; set; }
        public DateTime? AgrDate { get; set; }
        public string UserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? TradeId { get; set; }
        public string R030Offer { get; set; }
        public DateTime? StatusDate { get; set; }
        public string RAgrComment { get; set; }

        public Customer Cust { get; set; }
        public RightHolder CustIdRhNavigation { get; set; }
        public Request Req { get; set; }
        public ReqAgreementStatus StatusNavigation { get; set; }
        public ICollection<ReqTrade> ReqTrade { get; set; }
    }
}

