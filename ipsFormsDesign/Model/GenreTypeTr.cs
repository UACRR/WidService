using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class GenreTypeTr : IGenreTypeTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }
        public int CategoryCode { get; set; }

        public GenreType C { get; set; }
    }
}

