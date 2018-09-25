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
            relEtGenre = new HashSet<relEtGenre>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public int? categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public ICollection<EtGenreRate> EtGenreRate { get; set; }
        public ICollection<EtGenreRole> EtGenreRole { get; set; }
        public ICollection<relEtGenre> relEtGenre { get; set; }
    }
}
