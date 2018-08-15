using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Distribution
    {
        public Distribution()
        {
            DistributionItem = new HashSet<DistributionItem>();
        }

        public int DistId { get; set; }
        public int? RegId { get; set; }
        public int? PeriodId { get; set; }
        public int CRkindCode { get; set; }
        public int Status { get; set; }
        public DateTime DistribDate { get; set; }
        public decimal Amount { get; set; }
        public decimal PartnerCommiss { get; set; }
        public decimal CourtFee { get; set; }
        public int? PartnerId { get; set; }
        public bool? IsCourt { get; set; }
        public int? RegIdBr { get; set; }
        public int? DistType { get; set; }
        public int CustId { get; set; }

        [JsonIgnore]
        public CopyrightKind CRkindCodeNavigation { get; set; }
        [JsonIgnore]
        public Client Cust { get; set; }
        [JsonIgnore]
        public Partner Partner { get; set; }
        [JsonIgnore]
        public PaidPeriod Period { get; set; }
        [JsonIgnore]
        public Register Reg { get; set; }
        [JsonIgnore]
        public BrRegister RegIdBrNavigation { get; set; }
        [JsonIgnore]
        public DistribStatus StatusNavigation { get; set; }
        public ICollection<DistributionItem> DistributionItem { get; set; }
    }
}

