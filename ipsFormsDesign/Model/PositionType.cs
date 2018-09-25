using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PositionType : IPositionType
    {
        public PositionType()
        {
            PositionTypeTr = new ObservableListSource<PositionTypeTr>();
            RelEmployee = new ObservableListSource<RelEmployee>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<PositionTypeTr> PositionTypeTr { get; set; }
        public ObservableListSource<RelEmployee> RelEmployee { get; set; }
    }
}

