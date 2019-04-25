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
            PubÑatalogItem = new ObservableListSource<PubÑatalogItem>();
            RegisterCount = new ObservableListSource<RegisterCount>();
            ReqAgreement = new ObservableListSource<ReqAgreement>();
            RhñatalogItem = new ObservableListSource<RhñatalogItem>();
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

        public virtual Customer Cust { get; set; }
        public virtual ObservableListSource<AgreementAddRh> AgreementAddRh { get; set; }
        public virtual ObservableListSource<AnketaAddNick> AnketaAddNick { get; set; }
        public virtual ObservableListSource<Authors> Authors { get; set; }
        public virtual ObservableListSource<CatalogFile> CatalogFile { get; set; }
        public virtual ObservableListSource<CopyRight> CopyRight { get; set; }
        public virtual ObservableListSource<PubÑatalogItem> PubÑatalogItem { get; set; }
        public virtual ObservableListSource<RegisterCount> RegisterCount { get; set; }
        public virtual ObservableListSource<ReqAgreement> ReqAgreement { get; set; }
        public virtual ObservableListSource<RhñatalogItem> RhñatalogItem { get; set; }
        public virtual ObservableListSource<TermsOfService> TermsOfService { get; set; }
        public virtual ObservableListSource<TerritoryExclude> TerritoryExclude { get; set; }
        public virtual ObservableListSource<TerritoryInclude> TerritoryInclude { get; set; }
    }
}

