using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ClientBrand : IClientBrand
    {
        public ClientBrand()
        {
            ClientBrandTr = new ObservableListSource<ClientBrandTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<ClientBrandTr> ClientBrandTr { get; set; }
    }
}

