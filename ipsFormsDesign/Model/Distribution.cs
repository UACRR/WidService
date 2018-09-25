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

        public int distId { get; set; }
        public int? regId { get; set; }
        public int? rmId { get; set; }
        public int cRKindCode { get; set; }
        public int status { get; set; }
        public DateTime distribDate { get; set; }
        public decimal amount { get; set; }
        public decimal partnerCommiss { get; set; }
        public decimal courtFee { get; set; }
        public int? partnerId { get; set; }
        public bool? isCourt { get; set; }
        public int? regIdBr { get; set; }
        public int? distType { get; set; }
        public int custId { get; set; }

        public CopyrightKind cRKindCodeNavigation { get; set; }
        public Client cust { get; set; }
        public Partner partner { get; set; }
        public Register reg { get; set; }
        public BrRegister regIdBrNavigation { get; set; }
        public RegisterRatedList rm { get; set; }
        public DistribStatus statusNavigation { get; set; }
        public ObservableListSource<DistributionItem> DistributionItem { get; set; }
    }
}

