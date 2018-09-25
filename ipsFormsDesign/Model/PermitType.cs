using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PermitType : IPermitType
    {
        public PermitType()
        {
            PermitTypeTr = new ObservableListSource<PermitTypeTr>();
        }

        public bool codeB { get; set; }
        public string name { get; set; }

        public ObservableListSource<PermitTypeTr> PermitTypeTr { get; set; }
    }
}

