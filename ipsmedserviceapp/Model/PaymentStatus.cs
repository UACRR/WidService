using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PaymentStatus
    {
        public PaymentStatus()
        {
            DocPreparePay = new HashSet<DocPreparePay>();
            PayTurn = new HashSet<PayTurn>();
            PaymentStatusTr = new HashSet<PaymentStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DocPreparePay> DocPreparePay { get; set; }
        public virtual ICollection<PayTurn> PayTurn { get; set; }
        public virtual ICollection<PaymentStatusTr> PaymentStatusTr { get; set; }
    }
}
