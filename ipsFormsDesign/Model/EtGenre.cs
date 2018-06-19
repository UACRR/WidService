using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class EtGenre : IEtGenre
    {
        public EtGenre()
        {
            EtGenreRate = new HashSet<EtGenreRate>();
            EtGenreRole = new HashSet<EtGenreRole>();
            RelEtGenre = new HashSet<RelEtGenre>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? CategoryCode { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<EtGenreRate> EtGenreRate { get; set; }
        public ICollection<EtGenreRole> EtGenreRole { get; set; }
        public ICollection<RelEtGenre> RelEtGenre { get; set; }
    }
}

