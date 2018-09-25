using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TermsOfService : ITermsOfService
    {
        public TermsOfService()
        {
            CustCmRight = new ObservableListSource<CustCmRight>();
        }

        public int custId { get; set; }
        public int CRKindCode { get; set; }
        public bool ourService { get; set; }

        public CopyrightKind CRKindCodeNavigation { get; set; }
        public RightHolder cust { get; set; }
        public ObservableListSource<CustCmRight> CustCmRight { get; set; }
    }
}

