using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RightHolder : IRightHolder
    {
        public RightHolder()
        {
            AgreementAddRH = new ObservableListSource<AgreementAddRH>();
            AnketaAddNick = new ObservableListSource<AnketaAddNick>();
            Authors = new ObservableListSource<Authors>();
            CopyRight = new ObservableListSource<CopyRight>();
            RegisterCount = new ObservableListSource<RegisterCount>();
            ReqAgreement = new ObservableListSource<ReqAgreement>();
            TermsOfService = new ObservableListSource<TermsOfService>();
            TerritoryExclude = new ObservableListSource<TerritoryExclude>();
            TerritoryInclude = new ObservableListSource<TerritoryInclude>();
        }

        public int custId { get; set; }
        public byte? signP { get; set; }
        public bool? aroundWord { get; set; }
        public string interCode { get; set; }
        public string innerCode { get; set; }
        public int? rHolderType { get; set; }

        public Customer cust { get; set; }
        public ObservableListSource<AgreementAddRH> AgreementAddRH { get; set; }
        public ObservableListSource<AnketaAddNick> AnketaAddNick { get; set; }
        public ObservableListSource<Authors> Authors { get; set; }
        public ObservableListSource<CopyRight> CopyRight { get; set; }
        public ObservableListSource<RegisterCount> RegisterCount { get; set; }
        public ObservableListSource<ReqAgreement> ReqAgreement { get; set; }
        public ObservableListSource<TermsOfService> TermsOfService { get; set; }
        public ObservableListSource<TerritoryExclude> TerritoryExclude { get; set; }
        public ObservableListSource<TerritoryInclude> TerritoryInclude { get; set; }
    }
}

