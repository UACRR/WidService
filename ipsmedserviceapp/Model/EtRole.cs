using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class EtRole
    {
        public EtRole()
        {
            EtGenreRole = new HashSet<EtGenreRole>();
            relEtRole = new HashSet<relEtRole>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public int? categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public ICollection<EtGenreRole> EtGenreRole { get; set; }
        public ICollection<relEtRole> relEtRole { get; set; }
    }
}
