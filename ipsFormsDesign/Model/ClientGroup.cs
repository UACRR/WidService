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

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<ClientGroupTr> ClientGroupTr { get; set; }
    }
}

