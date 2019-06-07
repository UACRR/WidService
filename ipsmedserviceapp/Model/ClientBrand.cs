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

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ClientBrandTr> ClientBrandTr { get; set; }
    }
}
