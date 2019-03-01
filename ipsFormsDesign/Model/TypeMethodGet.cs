using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypeMethodGet : ITypeMethodGet
    {
        public TypeMethodGet()
        {
            AgreementAddRh = new ObservableListSource<AgreementAddRh>();
            TypeMethodGetTr = new ObservableListSource<TypeMethodGetTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<AgreementAddRh> AgreementAddRh { get; set; }
        public virtual ObservableListSource<TypeMethodGetTr> TypeMethodGetTr { get; set; }
    }
}

