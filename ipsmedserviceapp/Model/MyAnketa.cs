using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MyAnketa
    {
        public MyAnketa()
        {
            MyCategory = new HashSet<MyCategory>();
            MyCopyRightType = new HashSet<MyCopyRightType>();
        }

        public int CustId { get; set; }
        public string AccCompany { get; set; }
        public string AccCommission { get; set; }
        public string AccInCommission { get; set; }
        public string AccCourt { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ICollection<MyCategory> MyCategory { get; set; }
        public virtual ICollection<MyCopyRightType> MyCopyRightType { get; set; }
    }
}
