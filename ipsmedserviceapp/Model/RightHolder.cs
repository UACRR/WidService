using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RightHolder
    {
        public RightHolder()
        {
            AgreementAddRh = new HashSet<AgreementAddRh>();
            AnketaAddNick = new HashSet<AnketaAddNick>();
            Authors = new HashSet<Authors>();
            CopyRight = new HashSet<CopyRight>();
            RegisterCount = new HashSet<RegisterCount>();
            ReqAgreement = new HashSet<ReqAgreement>();
            TermsOfService = new HashSet<TermsOfService>();
            TerritoryExclude = new HashSet<TerritoryExclude>();
            TerritoryInclude = new HashSet<TerritoryInclude>();
        }

        public int CustId { get; set; }
        public byte? SignP { get; set; }
        public bool? AroundWord { get; set; }
        public string InterCode { get; set; }
        public string InnerCode { get; set; }
        public int? RHolderType { get; set; }

        public virtual Customer Cust { get; set; }
        [JsonIgnore]
        public virtual ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        public virtual ICollection<AnketaAddNick> AnketaAddNick { get; set; }
        [JsonIgnore]
        public virtual ICollection<Authors> Authors { get; set; }
        public virtual ICollection<CopyRight> CopyRight { get; set; }
        [JsonIgnore]
        public virtual ICollection<RegisterCount> RegisterCount { get; set; }
        [JsonIgnore]
        public virtual ICollection<ReqAgreement> ReqAgreement { get; set; }
        public virtual ICollection<TermsOfService> TermsOfService { get; set; }
        public virtual ICollection<TerritoryExclude> TerritoryExclude { get; set; }
        public virtual ICollection<TerritoryInclude> TerritoryInclude { get; set; }
    }
}

