using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementAddPartner
    {
        public int agrId { get; set; }
        public int? custId { get; set; }
        public decimal? srFirstRate { get; set; }
        public decimal? srMonthRate { get; set; }
        public decimal? pfFirstRate { get; set; }
        public decimal? pfMonthRate { get; set; }
        public decimal? courtRate { get; set; }
        public decimal? noCourtRate { get; set; }
        public decimal? courtCompRate { get; set; }
        public int version { get; set; }
        public string agrNumber { get; set; }
        public DateTime? agrDate { get; set; }
        public DateTime? dateBegin { get; set; }
        public DateTime? dateEnd { get; set; }
        public int? periodCode { get; set; }
        public int? agrStatus { get; set; }
        public int? dayForPay { get; set; }
        public int? ankVersion { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }

        public AgreementMaster agr { get; set; }
        public AgreementStatus agrStatusNavigation { get; set; }
        public Partner cust { get; set; }
        public Period periodCodeNavigation { get; set; }
    }
}
