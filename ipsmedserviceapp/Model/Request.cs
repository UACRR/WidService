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
            ReqTrade = new HashSet<ReqTrade>();
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

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual KindComposition KindCompCodeNavigation { get; set; }
        public virtual LicenseType LicCodeNavigation { get; set; }
        public virtual ObjectRight Obj { get; set; }
        public virtual RequestAim ReqAimCodeNavigation { get; set; }
        public virtual ReqCustomer ReqCust { get; set; }
        public virtual RequestType ReqTypeNavigation { get; set; }
        public virtual RequestStatusType ReqstatusNavigation { get; set; }
        public virtual TermUse TermUseCodeNavigation { get; set; }
        public virtual RequestAdapt RequestAdapt { get; set; }
        public virtual RequestAdvertising RequestAdvertising { get; set; }
        public virtual RequestInternet RequestInternet { get; set; }
        public virtual RequestMovie RequestMovie { get; set; }
        public virtual RequestOther RequestOther { get; set; }
        public virtual RequestSerial RequestSerial { get; set; }
        public virtual RequestTvradio RequestTvradio { get; set; }
        public virtual ICollection<DocReq> DocReq { get; set; }
        public virtual ICollection<RelReqMedia> RelReqMedia { get; set; }
        public virtual ICollection<ReqAgreement> ReqAgreement { get; set; }
        public virtual ICollection<ReqTrade> ReqTrade { get; set; }
    }
}
