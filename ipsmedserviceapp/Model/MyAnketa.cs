using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MyAnketa
    {
        public MyAnketa()
        {
            MyCategory = new HashSet<MyCategory>();
            myCopyRightType = new HashSet<myCopyRightType>();
        }

        public int custId { get; set; }
        public string accCompany { get; set; }
        public string accCommission { get; set; }
        public string accInCommission { get; set; }
        public string accCourt { get; set; }

        public Customer cust { get; set; }
        public ICollection<MyCategory> MyCategory { get; set; }
        public ICollection<myCopyRightType> myCopyRightType { get; set; }
    }
}
