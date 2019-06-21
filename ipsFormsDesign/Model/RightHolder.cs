using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RightHolder : IRightHolder
    {
        public RightHolder()
        {
            AgreementAddRh = new ObservableListSource<AgreementAddRh>();
            AnketaAddNick = new ObservableListSource<AnketaAddNick>();
            Authors = new ObservableListSource<Authors>();
            CatalogFile = new ObservableListSource<CatalogFile>();
            CopyRight = new ObservableListSource<CopyRight>();
            PubCatalogItem = new ObservableListSource<PubCatalogItem>();
            RegisterCount = new ObservableListSource<RegisterCount>();
            ReqAgreement = new ObservableListSource<ReqAgreement>();
            RhcatalogItem = new ObservableListSource<RhcatalogItem>();
            TermsOfService = new ObservableListSource<TermsOfService>();
            TerritoryExclude = new ObservableListSource<TerritoryExclude>();
            TerritoryInclude = new ObservableListSource<TerritoryInclude>();
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
        public virtual ObservableListSource<AgreementAddRh> AgreementAddRh { get; set; }
        public virtual ObservableListSource<AnketaAddNick> AnketaAddNick { get; set; }
        public virtual ObservableListSource<Authors> Authors { get; set; }
        public virtual ObservableListSource<CatalogFile> CatalogFile { get; set; }
        public virtual ObservableListSource<CopyRight> CopyRight { get; set; }
        public virtual ObservableListSource<PubCatalogItem> PubCatalogItem { get; set; }
        public virtual ObservableListSource<RegisterCount> RegisterCount { get; set; }
        public virtual ObservableListSource<ReqAgreement> ReqAgreement { get; set; }
        public virtual ObservableListSource<RhcatalogItem> RhcatalogItem { get; set; }
        public virtual ObservableListSource<TermsOfService> TermsOfService { get; set; }
        public virtual ObservableListSource<TerritoryExclude> TerritoryExclude { get; set; }
        public virtual ObservableListSource<TerritoryInclude> TerritoryInclude { get; set; }
    }
}

