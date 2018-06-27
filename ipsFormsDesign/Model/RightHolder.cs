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
            CopyRight = new ObservableListSource<CopyRight>();
            LicAuthorBr = new ObservableListSource<LicAuthorBr>();
            RegisterCount = new ObservableListSource<RegisterCount>();
            ReqAgreement = new ObservableListSource<ReqAgreement>();
            TermsOfService = new ObservableListSource<TermsOfService>();
            TerritoryExclude = new ObservableListSource<TerritoryExclude>();
            TerritoryInclude = new ObservableListSource<TerritoryInclude>();
        }

        public int CustId { get; set; }
        public byte? SignP { get; set; }
        public bool? AroundWord { get; set; }
        public string InterCode { get; set; }
        public string InnerCode { get; set; }

        public Customer Cust { get; set; }
        public ObservableListSource<AgreementAddRh> AgreementAddRh { get; set; }
        public ObservableListSource<AnketaAddNick> AnketaAddNick { get; set; }
        public ObservableListSource<Authors> Authors { get; set; }
        public ObservableListSource<CopyRight> CopyRight { get; set; }
        public ObservableListSource<LicAuthorBr> LicAuthorBr { get; set; }
        public ObservableListSource<RegisterCount> RegisterCount { get; set; }
        public ObservableListSource<ReqAgreement> ReqAgreement { get; set; }
        public ObservableListSource<TermsOfService> TermsOfService { get; set; }
        public ObservableListSource<TerritoryExclude> TerritoryExclude { get; set; }
        public ObservableListSource<TerritoryInclude> TerritoryInclude { get; set; }
    }
}

