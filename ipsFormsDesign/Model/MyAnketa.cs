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

        public virtual Customer Cust { get; set; }
        public virtual ObservableListSource<MyCategory> MyCategory { get; set; }
        public virtual ObservableListSource<MyCopyRightType> MyCopyRightType { get; set; }
    }
}

