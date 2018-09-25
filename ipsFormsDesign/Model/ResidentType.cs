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

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
        public ObservableListSource<ResidentTypeTr> ResidentTypeTr { get; set; }
    }
}

