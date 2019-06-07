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

        public int CustId { get; set; }
        public int CrkindCode { get; set; }
        public bool OurService { get; set; }

        public virtual CopyrightKind CrkindCodeNavigation { get; set; }
        public virtual RightHolder Cust { get; set; }
        public virtual ObservableListSource<CustCmRight> CustCmRight { get; set; }
    }
}

