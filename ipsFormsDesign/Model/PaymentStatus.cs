using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PaymentStatus : IPaymentStatus
    {
        public PaymentStatus()
        {
            DocPreparePay = new ObservableListSource<DocPreparePay>();
            PayTurn = new ObservableListSource<PayTurn>();
            PaymentStatusTr = new ObservableListSource<PaymentStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<DocPreparePay> DocPreparePay { get; set; }
        public virtual ObservableListSource<PayTurn> PayTurn { get; set; }
        public virtual ObservableListSource<PaymentStatusTr> PaymentStatusTr { get; set; }
    }
}

