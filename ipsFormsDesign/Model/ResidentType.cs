using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ResidentType : IResidentType
    {
        public ResidentType()
        {
            AnketaPerson = new ObservableListSource<AnketaPerson>();
            ResidentTypeTr = new ObservableListSource<ResidentTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
        public virtual ObservableListSource<ResidentTypeTr> ResidentTypeTr { get; set; }
    }
}

