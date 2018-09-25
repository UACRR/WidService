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

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<RegisterItem> RegisterItem { get; set; }
    }
}

