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

        public int CodeI { get; set; }
        public string Name { get; set; }
        public string TemplateName { get; set; }

        public virtual ObservableListSource<AgreementMaster> AgreementMaster { get; set; }
        public virtual ObservableListSource<AgreementTypeTr> AgreementTypeTr { get; set; }
        public virtual ObservableListSource<RelDocAgrType> RelDocAgrType { get; set; }
    }
}

