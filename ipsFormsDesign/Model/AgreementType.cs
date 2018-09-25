using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgreementType : IAgreementType
    {
        public AgreementType()
        {
            AgreementMaster = new ObservableListSource<AgreementMaster>();
            AgreementTypeTr = new ObservableListSource<AgreementTypeTr>();
            RelDocAgrType = new ObservableListSource<RelDocAgrType>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public string templateName { get; set; }

        public ObservableListSource<AgreementMaster> AgreementMaster { get; set; }
        public ObservableListSource<AgreementTypeTr> AgreementTypeTr { get; set; }
        public ObservableListSource<RelDocAgrType> RelDocAgrType { get; set; }
    }
}

