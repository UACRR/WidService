using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ClientGroup : IClientGroup
    {
        public ClientGroup()
        {
            ClientGroupTr = new ObservableListSource<ClientGroupTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<ClientGroupTr> ClientGroupTr { get; set; }
    }
}

