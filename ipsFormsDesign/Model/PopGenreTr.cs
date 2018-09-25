using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PopGenreTr : IPopGenreTr
    {
        public int Id { get; set; }
        public string lang { get; set; }
        public string name { get; set; }

        public PopGenre IdNavigation { get; set; }
    }
}

