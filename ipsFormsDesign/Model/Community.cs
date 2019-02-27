using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Community : ICommunity
    {
        public Community()
        {
            AgreementAddCommunity = new ObservableListSource<AgreementAddCommunity>();
            CustCmRight = new ObservableListSource<CustCmRight>();
            RegisterCount = new ObservableListSource<RegisterCount>();
        }

        public int CustId { get; set; }
        public string InterCode { get; set; }
        public string InnerCode { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ObservableListSource<AgreementAddCommunity> AgreementAddCommunity { get; set; }
        public virtual ObservableListSource<CustCmRight> CustCmRight { get; set; }
        public virtual ObservableListSource<RegisterCount> RegisterCount { get; set; }
    }
}

