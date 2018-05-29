using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class GenreType : IGenreType
    {
        public GenreType()
        {
            GenreTypeTr = new HashSet<GenreTypeTr>();
            ObjectRight = new HashSet<ObjectRight>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<GenreTypeTr> GenreTypeTr { get; set; }
        public ICollection<ObjectRight> ObjectRight { get; set; }
    }
}

