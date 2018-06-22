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
            MyCopyRightType = new ObservableListSource<MyCopyRightType>();
        }

        public int CustId { get; set; }
        public string AccCompany { get; set; }
        public string AccCommission { get; set; }
        public string AccInCommission { get; set; }
        public string AccCourt { get; set; }

        public Customer Cust { get; set; }
        public ObservableListSource<MyCategory> MyCategory { get; set; }
        public ObservableListSource<MyCopyRightType> MyCopyRightType { get; set; }
    }
}

