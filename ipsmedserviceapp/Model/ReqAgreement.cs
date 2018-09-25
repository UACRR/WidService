using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ReqAgreement
    {
        public ReqAgreement()
        {
            ReqTrade = new HashSet<ReqTrade>();
        }

        public int rAgrId { get; set; }
        public int custId { get; set; }
        public int? custIdRh { get; set; }
        public int? reqId { get; set; }
        public string r030 { get; set; }
        public decimal? amount { get; set; }
        public decimal? costOffer { get; set; }
        public int status { get; set; }
        public DateTime? agrDate { get; set; }
        public string userId { get; set; }
        public DateTime? modifyDate { get; set; }
        public int? tradeId { get; set; }
        public string r030Offer { get; set; }
        public DateTime? statusDate { get; set; }
        public string rAgrComment { get; set; }

        public Customer cust { get; set; }
        public RightHolder custIdRhNavigation { get; set; }
        public Request req { get; set; }
        public ReqAgreementStatus statusNavigation { get; set; }
        public ICollection<ReqTrade> ReqTrade { get; set; }
    }
}
