using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AnketaStatus : IAnketaStatus
    {
        public AnketaStatus()
        {
            AnketaCompany = new ObservableListSource<AnketaCompany>();
            AnketaPerson = new ObservableListSource<AnketaPerson>();
            AnketaStatusTr = new ObservableListSource<AnketaStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<AnketaCompany> AnketaCompany { get; set; }
        public virtual ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
        public virtual ObservableListSource<AnketaStatusTr> AnketaStatusTr { get; set; }
    }
}

