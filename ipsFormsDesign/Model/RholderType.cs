using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RHolderType : IRHolderType
    {
        public RHolderType()
        {
            RHolderTypeTr = new ObservableListSource<RHolderTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<RHolderTypeTr> RHolderTypeTr { get; set; }
    }
}

