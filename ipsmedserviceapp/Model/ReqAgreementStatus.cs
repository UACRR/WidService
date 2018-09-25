using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ReqAgreementStatus
    {
        public ReqAgreementStatus()
        {
            ReqAgreement = new HashSet<ReqAgreement>();
        }

        public int StatusCode { get; set; }
        public string StatusNameUk { get; set; }
        public string StatusNameRu { get; set; }
        public string StatusNameEn { get; set; }

        public ICollection<ReqAgreement> ReqAgreement { get; set; }
    }
}
