using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class EtGenre
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

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual ICollection<EtGenreRate> EtGenreRate { get; set; }
        public virtual ICollection<EtGenreRole> EtGenreRole { get; set; }
        public virtual ICollection<RelEtGenre> RelEtGenre { get; set; }
    }
}
