using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CRightStatus : ICRightStatus
    {
        public CRightStatus()
        {
            CRightStatusTr = new ObservableListSource<CRightStatusTr>();
            CopyRight = new ObservableListSource<CopyRight>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<CRightStatusTr> CRightStatusTr { get; set; }
        public ObservableListSource<CopyRight> CopyRight { get; set; }
    }
}

