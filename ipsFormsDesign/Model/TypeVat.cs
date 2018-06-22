using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypeVat : ITypeVat
    {
        public TypeVat()
        {
            AnketaCompany = new ObservableListSource<AnketaCompany>();
            AnketaPerson = new ObservableListSource<AnketaPerson>();
            TypeVattr = new ObservableListSource<TypeVattr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<AnketaCompany> AnketaCompany { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
        public ObservableListSource<TypeVattr> TypeVattr { get; set; }
    }
}

