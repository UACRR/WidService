using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ClientBrand
    {
        public ClientBrand()
        {
            ClientBrandTr = new HashSet<ClientBrandTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<ClientBrandTr> ClientBrandTr { get; set; }
    }
}
