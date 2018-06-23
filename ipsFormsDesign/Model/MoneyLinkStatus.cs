using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MoneyLinkStatus : IMoneyLinkStatus
    {
        public MoneyLinkStatus()
        {
            MoneyLinkStatusTr = new ObservableListSource<MoneyLinkStatusTr>();
            MoneyPeriodLink = new ObservableListSource<MoneyPeriodLink>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<MoneyLinkStatusTr> MoneyLinkStatusTr { get; set; }
        public ObservableListSource<MoneyPeriodLink> MoneyPeriodLink { get; set; }
    }
}

