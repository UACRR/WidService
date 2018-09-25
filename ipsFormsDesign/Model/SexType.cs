using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SexType : ISexType
    {
        public SexType()
        {
            AnketaPerson = new ObservableListSource<AnketaPerson>();
            SexTypeTr = new ObservableListSource<SexTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
        public ObservableListSource<SexTypeTr> SexTypeTr { get; set; }
    }
}

