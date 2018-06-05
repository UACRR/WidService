using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class EtRole : IEtRole
    {
        public EtRole()
        {
            EtGenreRole = new HashSet<EtGenreRole>();
            RelEtRole = new HashSet<RelEtRole>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? CategoryCode { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<EtGenreRole> EtGenreRole { get; set; }
        public ICollection<RelEtRole> RelEtRole { get; set; }
    }
}

