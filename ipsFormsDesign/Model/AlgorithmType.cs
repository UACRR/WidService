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
            AlgorithmTypeTr = new ObservableListSource<AlgorithmTypeTr>();
            Register = new ObservableListSource<Register>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<AgrLicenseType> AgrLicenseType { get; set; }
        public virtual ObservableListSource<AlgorithmTypeTr> AlgorithmTypeTr { get; set; }
        public virtual ObservableListSource<Register> Register { get; set; }
    }
}

