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

        [JsonIgnore]
        public CopyrightKind cRKindCodeNavigation { get; set; }
        [JsonIgnore]
        public Client cust { get; set; }
        [JsonIgnore]
        public Partner partner { get; set; }
        [JsonIgnore]
        public Register reg { get; set; }
        [JsonIgnore]
        public BrRegister regIdBrNavigation { get; set; }
        [JsonIgnore]
        public RegisterRatedList rm { get; set; }
        [JsonIgnore]
        public DistribStatus statusNavigation { get; set; }
        public ICollection<DistributionItem> DistributionItem { get; set; }
    }
}

