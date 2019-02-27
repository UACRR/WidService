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

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<SeekObject> SeekObject { get; set; }
        public virtual ObservableListSource<SeekTypeTr> SeekTypeTr { get; set; }
    }
}

