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

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<PositionTypeTr> PositionTypeTr { get; set; }
        public ObservableListSource<RelEmployee> RelEmployee { get; set; }
    }
}

