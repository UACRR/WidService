using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgreementAddRH : IAgreementAddRH
    {
        public int agrId { get; set; }
        public decimal? rateCourt { get; set; }
        public decimal? rateCommiss { get; set; }
        public string responsUser { get; set; }
        public int? custId { get; set; }
        public int version { get; set; }
        public string agrNumber { get; set; }
        public DateTime? agrDate { get; set; }
        public DateTime? dateBegin { get; set; }
        public DateTime? dateEnd { get; set; }
        public int? periodCode { get; set; }
        public int? dayForPay { get; set; }
        public int? ankVersion { get; set; }
        public int? agrStatus { get; set; }
        public int? getCode { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }

        public AgreementMaster agr { get; set; }
        public AgreementStatus agrStatusNavigation { get; set; }
        public RightHolder cust { get; set; }
        public TypeMethodGet getCodeNavigation { get; set; }
        public Period periodCodeNavigation { get; set; }
        public AspNetUsers responsUserNavigation { get; set; }
    }
}

