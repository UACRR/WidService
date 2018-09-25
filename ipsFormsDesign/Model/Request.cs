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

        public int ReqId { get; set; }
        public int? CategoryCode { get; set; }
        public int ReqType { get; set; }
        public DateTime? ReqDate { get; set; }
        public int? CountUse { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Reqstatus { get; set; }
        public int? CustId { get; set; }
        public string UserId { get; set; }
        public int ReqAimCode { get; set; }
        public int? ObjId { get; set; }
        public int? KindCompCode { get; set; }
        public int? TermUseCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public int? LicCode { get; set; }
        public int? ReqCustId { get; set; }
        public string ReqComment { get; set; }
        public string R030 { get; set; }
        public decimal? ReqAmount { get; set; }
        public string WorkName { get; set; }
        public TimeSpan? DurationUse { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public Customer Cust { get; set; }
        public KindComposition KindCompCodeNavigation { get; set; }
        public LicenseType LicCodeNavigation { get; set; }
        public ObjectRight Obj { get; set; }
        public RequestAim ReqAimCodeNavigation { get; set; }
        public ReqCustomer ReqCust { get; set; }
        public RequestType ReqTypeNavigation { get; set; }
        public RequestStatusType ReqstatusNavigation { get; set; }
        public TermUse TermUseCodeNavigation { get; set; }
        public AspNetUsers User { get; set; }
        public PaymentCase PaymentCase { get; set; }
        public RequestAdapt RequestAdapt { get; set; }
        public RequestAdvertising RequestAdvertising { get; set; }
        public RequestInternet RequestInternet { get; set; }
        public RequestMovie RequestMovie { get; set; }
        public RequestOther RequestOther { get; set; }
        public RequestSerial RequestSerial { get; set; }
        public RequestTvradio RequestTvradio { get; set; }
        public ObservableListSource<DocReq> DocReq { get; set; }
        public ObservableListSource<RelReqMedia> RelReqMedia { get; set; }
        public ObservableListSource<ReqAgreement> ReqAgreement { get; set; }
        public ObservableListSource<ReqLocationUse> ReqLocationUse { get; set; }
        public ObservableListSource<ReqTrade> ReqTrade { get; set; }
    }
}

