using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ReqAgreementStatus : IReqAgreementStatus
    {
        public ReqAgreementStatus()
        {
            ReqAgreement = new ObservableListSource<ReqAgreement>();
        }

        public int StatusCode { get; set; }
        public string StatusNameUk { get; set; }
        public string StatusNameRu { get; set; }
        public string StatusNameEn { get; set; }

        public ObservableListSource<ReqAgreement> ReqAgreement { get; set; }
    }
}

