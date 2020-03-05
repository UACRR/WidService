using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Invoice
    {
        public int InvId { get; set; }
        public int? LicId { get; set; }
        public int? PayCustId { get; set; }
        public int? RecCustId { get; set; }
        public int? PayAnk { get; set; }
        public int? RecAnk { get; set; }
        public string RecMfo { get; set; }
        public string RecBankName { get; set; }
        public string RecAccount { get; set; }
        public string R030 { get; set; }
        public decimal? Amount { get; set; }
        public string Details { get; set; }
        public string InvNumber { get; set; }
        public DateTime? InvDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string UserId { get; set; }
        public DateTime? DateForPay { get; set; }
        public int? InvStatus { get; set; }
        public int? PayServiceType { get; set; }
        public string ApprovalCode { get; set; }
        public string Locale { get; set; }
        public string ProxyPan { get; set; }
        public string PurchaseTime { get; set; }
        public string Rrn { get; set; }
        public string TranCode { get; set; }
        public string XId { get; set; }

        public virtual InvoiceStatus InvStatusNavigation { get; set; }
        public virtual LicenseAgreement Lic { get; set; }
        public virtual PayServiceType PayServiceTypeNavigation { get; set; }
    }
}
