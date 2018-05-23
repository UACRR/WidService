using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Partner : IPartner
    {
        public Partner()
        {
            AgreementAddPartner = new HashSet<AgreementAddPartner>();
            Distribution = new HashSet<Distribution>();
        }

        public int CustId { get; set; }

        public Customer Cust { get; set; }
        public ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
    }
}

