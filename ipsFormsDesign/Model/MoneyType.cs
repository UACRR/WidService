using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MoneyType : IMoneyType
    {
        public MoneyType()
        {
            MoneyReceived = new ObservableListSource<MoneyReceived>();
            MoneyTypeTr = new ObservableListSource<MoneyTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<MoneyReceived> MoneyReceived { get; set; }
        public ObservableListSource<MoneyTypeTr> MoneyTypeTr { get; set; }
    }
}

