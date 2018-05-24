using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypePlace : ITypePlace
    {
        public TypePlace()
        {
            ClnBusinessPlace = new HashSet<ClnBusinessPlace>();
            TypePlaceTr = new HashSet<TypePlaceTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        public ICollection<TypePlaceTr> TypePlaceTr { get; set; }
    }
}

