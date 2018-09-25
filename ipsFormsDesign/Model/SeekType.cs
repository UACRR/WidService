using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SeekType : ISeekType
    {
        public SeekType()
        {
            SeekObject = new ObservableListSource<SeekObject>();
            SeekTypeTr = new ObservableListSource<SeekTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<SeekObject> SeekObject { get; set; }
        public ObservableListSource<SeekTypeTr> SeekTypeTr { get; set; }
    }
}

