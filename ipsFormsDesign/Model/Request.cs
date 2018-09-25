using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Request : IRequest
    {
        public Request()
        {
            DocReq = new ObservableListSource<DocReq>();
            RelReqMedia = new ObservableListSource<RelReqMedia>();
            ReqAgreement = new ObservableListSource<ReqAgreement>();
            ReqLocationUse = new ObservableListSource<ReqLocationUse>();
            ReqTrade = new ObservableListSource<ReqTrade>();
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
        public ObservableListSource<DocReq> DocReq { get; set; }
        public ObservableListSource<RelReqMedia> RelReqMedia { get; set; }
        public ObservableListSource<ReqAgreement> ReqAgreement { get; set; }
        public ObservableListSource<ReqLocationUse> ReqLocationUse { get; set; }
        public ObservableListSource<ReqTrade> ReqTrade { get; set; }
    }
}

