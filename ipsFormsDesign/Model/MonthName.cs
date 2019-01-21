using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MonthName : IMonthName
    {
        public MonthName()
        {
            MonthNameTr = new ObservableListSource<MonthNameTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<MonthNameTr> MonthNameTr { get; set; }
    }
}

