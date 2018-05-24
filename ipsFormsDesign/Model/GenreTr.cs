using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class GenreTr : IGenreTr
    {
        public int Id { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public Genre IdNavigation { get; set; }
    }
}

