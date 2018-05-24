using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PaymentStatus : IPaymentStatus
    {
        public PaymentStatus()
        {
            DocPreparePay = new HashSet<DocPreparePay>();
            PayTurn = new HashSet<PayTurn>();
            PaymentStatusTr = new HashSet<PaymentStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<DocPreparePay> DocPreparePay { get; set; }
        public ICollection<PayTurn> PayTurn { get; set; }
        public ICollection<PaymentStatusTr> PaymentStatusTr { get; set; }
    }
}

