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

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<ClientBrandTr> ClientBrandTr { get; set; }
    }
}

