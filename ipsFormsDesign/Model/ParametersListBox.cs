using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ParametersListBox : IParametersListBox
    {
        public int RepId { get; set; }
        public int PId { get; set; }
        public string ValuePar { get; set; }
        public string ValueType { get; set; }
        public string ValueName { get; set; }
    }
}

