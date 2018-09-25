using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypeVAT : ITypeVAT
    {
        public TypeVAT()
        {
            AnketaCompany = new ObservableListSource<AnketaCompany>();
            AnketaPerson = new ObservableListSource<AnketaPerson>();
            TypeVATTr = new ObservableListSource<TypeVATTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<AnketaCompany> AnketaCompany { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
        public ObservableListSource<TypeVATTr> TypeVATTr { get; set; }
    }
}

