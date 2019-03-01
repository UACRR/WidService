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

        public bool CodeB { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<PermitTypeTr> PermitTypeTr { get; set; }
    }
}

