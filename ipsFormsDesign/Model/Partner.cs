using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Partner : IPartner
    {
        public Partner()
        {
            AgreementAddPartner = new ObservableListSource<AgreementAddPartner>();
            Distribution = new ObservableListSource<Distribution>();
            Fixation = new ObservableListSource<Fixation>();
            PartnerClient = new ObservableListSource<PartnerClient>();
        }

        public int CustId { get; set; }
        public bool? IsMy { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ObservableListSource<AgreementAddPartner> AgreementAddPartner { get; set; }
        public virtual ObservableListSource<Distribution> Distribution { get; set; }
        public virtual ObservableListSource<Fixation> Fixation { get; set; }
        public virtual ObservableListSource<PartnerClient> PartnerClient { get; set; }
    }
}

