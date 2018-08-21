using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AlgorithmType : IAlgorithmType
    {
        public AlgorithmType()
        {
            AgrLicenseType = new ObservableListSource<AgrLicenseType>();
            Register = new ObservableListSource<Register>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<AgrLicenseType> AgrLicenseType { get; set; }
        public ObservableListSource<Register> Register { get; set; }
    }
}

