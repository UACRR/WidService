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
            LicAuthor = new HashSet<LicAuthor>();
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

        [JsonIgnore]
        public Customer Cust { get; set; }
        [JsonIgnore]
        public ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        public ICollection<AnketaAddNick> AnketaAddNick { get; set; }
        [JsonIgnore]
        public ICollection<Authors> Authors { get; set; }
        public ICollection<CopyRight> CopyRight { get; set; }
        [JsonIgnore]
        public ICollection<LicAuthor> LicAuthor { get; set; }
        [JsonIgnore]
        public ICollection<RegisterCount> RegisterCount { get; set; }
        [JsonIgnore]
        public ICollection<ReqAgreement> ReqAgreement { get; set; }
        public ICollection<TermsOfService> TermsOfService { get; set; }
        public ICollection<TerritoryExclude> TerritoryExclude { get; set; }
        public ICollection<TerritoryInclude> TerritoryInclude { get; set; }
    }
}

