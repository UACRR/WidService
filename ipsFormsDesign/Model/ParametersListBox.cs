using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ParametersListBox : IParametersListBox
    {
        public int repId { get; set; }
        public int pId { get; set; }
        public string valuePar { get; set; }
        public string valueType { get; set; }
        public string valueName { get; set; }
    }
}

