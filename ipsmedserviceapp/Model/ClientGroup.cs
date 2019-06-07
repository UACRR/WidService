using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ClientGroup
    {
        public ClientGroup()
        {
            ClientGroupTr = new HashSet<ClientGroupTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ClientGroupTr> ClientGroupTr { get; set; }
    }
}
