using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PrePayType : IPrePayType
    {
        public PrePayType()
        {
            LicAuthorBR = new ObservableListSource<LicAuthorBR>();
            PrePayTypeTr = new ObservableListSource<PrePayTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<LicAuthorBR> LicAuthorBR { get; set; }
        public ObservableListSource<PrePayTypeTr> PrePayTypeTr { get; set; }
    }
}

