using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterListStatus : IRegisterListStatus
    {
        public RegisterListStatus()
        {
            RegisterListStatusTr = new ObservableListSource<RegisterListStatusTr>();
            RegisterRatedList = new ObservableListSource<RegisterRatedList>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<RegisterListStatusTr> RegisterListStatusTr { get; set; }
        public ObservableListSource<RegisterRatedList> RegisterRatedList { get; set; }
    }
}

