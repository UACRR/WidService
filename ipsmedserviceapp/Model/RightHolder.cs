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
            CatalogFile = new HashSet<CatalogFile>();
            CopyRight = new HashSet<CopyRight>();
            PubCatalogItem = new HashSet<PubCatalogItem>();
            RegisterCount = new HashSet<RegisterCount>();
            RelSubPublishCustIdPubNavigation = new HashSet<RelSubPublish>();
            RelSubPublishCustIdSubNavigation = new HashSet<RelSubPublish>();
            ReqAgreement = new HashSet<ReqAgreement>();
            RhcatalogItem = new HashSet<RhcatalogItem>();
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
        public string Ipibase { get; set; }
        public string Comment { get; set; }
        public DateTime? DatePassed { get; set; }

        public virtual Customer Cust { get; set; }
        [JsonIgnore]
        public virtual ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        public virtual ICollection<AnketaAddNick> AnketaAddNick { get; set; }
        [JsonIgnore]
        public virtual ICollection<Authors> Authors { get; set; }
        [JsonIgnore]
        public virtual ICollection<CatalogFile> CatalogFile { get; set; }
        public virtual ICollection<CopyRight> CopyRight { get; set; }
        [JsonIgnore]
        public virtual ICollection<PubCatalogItem> PubCatalogItem { get; set; }
        [JsonIgnore]
        public virtual ICollection<RegisterCount> RegisterCount { get; set; }
        [JsonIgnore]
        public virtual ICollection<RelSubPublish> RelSubPublishCustIdPubNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<RelSubPublish> RelSubPublishCustIdSubNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<ReqAgreement> ReqAgreement { get; set; }
        [JsonIgnore]
        public virtual ICollection<RhcatalogItem> RhcatalogItem { get; set; }
        public virtual ICollection<TermsOfService> TermsOfService { get; set; }
        public virtual ICollection<TerritoryExclude> TerritoryExclude { get; set; }
        public virtual ICollection<TerritoryInclude> TerritoryInclude { get; set; }
    }
}

