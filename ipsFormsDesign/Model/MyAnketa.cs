using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MyAnketa : IMyAnketa
    {
        public MyAnketa()
        {
            MyCategory = new ObservableListSource<MyCategory>();
            myCopyRightType = new ObservableListSource<myCopyRightType>();
        }

        public int custId { get; set; }
        public string accCompany { get; set; }
        public string accCommission { get; set; }
        public string accInCommission { get; set; }
        public string accCourt { get; set; }

        public Customer cust { get; set; }
        public ObservableListSource<MyCategory> MyCategory { get; set; }
        public ObservableListSource<myCopyRightType> myCopyRightType { get; set; }
    }
}

