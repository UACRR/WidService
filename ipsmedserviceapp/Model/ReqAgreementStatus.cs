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

        public int statusCode { get; set; }
        public string statusNameUk { get; set; }
        public string statusNameRu { get; set; }
        public string statusNameEn { get; set; }

        public ICollection<ReqAgreement> ReqAgreement { get; set; }
    }
}
