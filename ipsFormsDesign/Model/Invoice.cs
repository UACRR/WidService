using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Invoice : IInvoice
    {
        public int DocId { get; set; }
        public int? PayCustId { get; set; }
        public int? RecCustId { get; set; }
        public int? PayAnk { get; set; }
        public int? RecAnk { get; set; }
        public string R030 { get; set; }
        public decimal? Amount { get; set; }
        public string RecMfo { get; set; }
        public string RecBankName { get; set; }
        public string Purpose { get; set; }
        public int? Status { get; set; }
    }
}

