using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterItemType : IRegisterItemType
    {
        public RegisterItemType()
        {
            RegisterItem = new ObservableListSource<RegisterItem>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<RegisterItem> RegisterItem { get; set; }
    }
}

