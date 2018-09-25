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

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<ClientGroupTr> ClientGroupTr { get; set; }
    }
}
