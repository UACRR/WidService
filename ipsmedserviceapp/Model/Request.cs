using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Request
    {
        public Request()
        {
            DocReq = new HashSet<DocReq>();
            RelReqMedia = new HashSet<RelReqMedia>();
            ReqAgreement = new HashSet<ReqAgreement>();
            ReqLocationUse = new HashSet<ReqLocationUse>();
            ReqTrade = new HashSet<ReqTrade>();
        }

        public int reqId { get; set; }
        public int? categoryCode { get; set; }
        public int reqType { get; set; }
        public DateTime? reqDate { get; set; }
        public int? countUse { get; set; }
        public DateTime? beginDate { get; set; }
        public DateTime? endDate { get; set; }
        public int reqstatus { get; set; }
        public int? custId { get; set; }
        public string userId { get; set; }
        public int reqAimCode { get; set; }
        public int? objId { get; set; }
        public int? kindCompCode { get; set; }
        public int? termUseCode { get; set; }
        public DateTime? createDate { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }
        public int? licCode { get; set; }
        public int? reqCustId { get; set; }
        public string reqComment { get; set; }
        public string r030 { get; set; }
        public decimal? reqAmount { get; set; }
        public string workName { get; set; }
        public TimeSpan? durationUse { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public Customer cust { get; set; }
        public KindComposition kindCompCodeNavigation { get; set; }
        public LicenseType licCodeNavigation { get; set; }
        public ObjectRight obj { get; set; }
        public RequestAim reqAimCodeNavigation { get; set; }
        public ReqCustomer reqCust { get; set; }
        public RequestType reqTypeNavigation { get; set; }
        public RequestStatusType reqstatusNavigation { get; set; }
        public TermUse termUseCodeNavigation { get; set; }
        public AspNetUsers user { get; set; }
        public PaymentCase PaymentCase { get; set; }
        public RequestAdapt RequestAdapt { get; set; }
        public RequestAdvertising RequestAdvertising { get; set; }
        public RequestInternet RequestInternet { get; set; }
        public RequestMovie RequestMovie { get; set; }
        public RequestOther RequestOther { get; set; }
        public RequestSerial RequestSerial { get; set; }
        public RequestTVRadio RequestTVRadio { get; set; }
        public ICollection<DocReq> DocReq { get; set; }
        public ICollection<RelReqMedia> RelReqMedia { get; set; }
        public ICollection<ReqAgreement> ReqAgreement { get; set; }
        public ICollection<ReqLocationUse> ReqLocationUse { get; set; }
        public ICollection<ReqTrade> ReqTrade { get; set; }
    }
}
