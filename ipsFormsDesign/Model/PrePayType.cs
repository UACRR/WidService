using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PrePayType : IPrePayType
    {
        public PrePayType()
        {
            LicAuthorBr = new ObservableListSource<LicAuthorBr>();
            PrePayTypeTr = new ObservableListSource<PrePayTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<LicAuthorBr> LicAuthorBr { get; set; }
        public virtual ObservableListSource<PrePayTypeTr> PrePayTypeTr { get; set; }
    }
}

