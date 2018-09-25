using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Distribution : IDistribution
    {
        public Distribution()
        {
            DistributionItem = new ObservableListSource<DistributionItem>();
        }

        public int DistId { get; set; }
        public int? RegId { get; set; }
        public int? RmId { get; set; }
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

        public CopyrightKind CRkindCodeNavigation { get; set; }
        public Client Cust { get; set; }
        public Partner Partner { get; set; }
        public Register Reg { get; set; }
        public BrRegister RegIdBrNavigation { get; set; }
        public RegisterRatedList Rm { get; set; }
        public DistribStatus StatusNavigation { get; set; }
        public ObservableListSource<DistributionItem> DistributionItem { get; set; }
    }
}

