using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RightHolder
    {
        public RightHolder()
        {
            AgreementAddRH = new HashSet<AgreementAddRH>();
            AnketaAddNick = new HashSet<AnketaAddNick>();
            Authors = new HashSet<Authors>();
            CopyRight = new HashSet<CopyRight>();
            RegisterCount = new HashSet<RegisterCount>();
            ReqAgreement = new HashSet<ReqAgreement>();
            TermsOfService = new HashSet<TermsOfService>();
            TerritoryExclude = new HashSet<TerritoryExclude>();
            TerritoryInclude = new HashSet<TerritoryInclude>();
        }

        public int custId { get; set; }
        public byte? signP { get; set; }
        public bool? aroundWord { get; set; }
        public string interCode { get; set; }
        public string innerCode { get; set; }
        public int? rHolderType { get; set; }

        [JsonIgnore]
        public Customer cust { get; set; }
        [JsonIgnore]
        public ICollection<AgreementAddRH> AgreementAddRH { get; set; }
        public ICollection<AnketaAddNick> AnketaAddNick { get; set; }
        [JsonIgnore]
        public ICollection<Authors> Authors { get; set; }
        public ICollection<CopyRight> CopyRight { get; set; }
        [JsonIgnore]
        public ICollection<RegisterCount> RegisterCount { get; set; }
        [JsonIgnore]
        public ICollection<ReqAgreement> ReqAgreement { get; set; }
        public ICollection<TermsOfService> TermsOfService { get; set; }
        public ICollection<TerritoryExclude> TerritoryExclude { get; set; }
        public ICollection<TerritoryInclude> TerritoryInclude { get; set; }
    }
}

