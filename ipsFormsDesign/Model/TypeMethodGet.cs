using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypeMethodGet : ITypeMethodGet
    {
        public TypeMethodGet()
        {
            AgreementAddRH = new ObservableListSource<AgreementAddRH>();
            TypeMethodGetTr = new ObservableListSource<TypeMethodGetTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<AgreementAddRH> AgreementAddRH { get; set; }
        public ObservableListSource<TypeMethodGetTr> TypeMethodGetTr { get; set; }
    }
}

