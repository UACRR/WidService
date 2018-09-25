using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CustCmRight : ICustCmRight
    {
        public int custId { get; set; }
        public int cRKindCode { get; set; }
        public int cmCustId { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }

        public TermsOfService c { get; set; }
        public Community cmCust { get; set; }
    }
}

