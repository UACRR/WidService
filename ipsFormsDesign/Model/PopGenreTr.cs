using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PopGenreTr : IPopGenreTr
    {
        public int Id { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public virtual PopGenre IdNavigation { get; set; }
    }
}

