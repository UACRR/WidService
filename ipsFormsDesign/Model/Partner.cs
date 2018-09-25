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

        public int custId { get; set; }

        public Customer cust { get; set; }
        public ObservableListSource<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ObservableListSource<Distribution> Distribution { get; set; }
        public ObservableListSource<Fixation> Fixation { get; set; }
        public ObservableListSource<PartnerClient> PartnerClient { get; set; }
    }
}

