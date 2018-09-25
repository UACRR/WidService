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

        public int statusCode { get; set; }
        public string statusNameUk { get; set; }
        public string statusNameRu { get; set; }
        public string statusNameEn { get; set; }

        public ObservableListSource<ReqAgreement> ReqAgreement { get; set; }
    }
}

