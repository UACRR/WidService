using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Dictionary
{
    public class TermsOfServiceWrapper
    {
        TermsOfService _termsOfService;
        CustCmRight _custCmRight;

        public TermsOfServiceWrapper(TermsOfService termsOfService)
        {
            _termsOfService = termsOfService;
            _custCmRight = termsOfService.CustCmRight.SingleOrDefault();
            if (_custCmRight == null)
            {
                _custCmRight = new CustCmRight();
                _termsOfService.CustCmRight.Add(_custCmRight);
            }
                
        }

        public string Name
        {
            get
            {
                return _termsOfService.CrkindCodeNavigation.Name;
            }
        }

        public int GroupCode
        {
            get
            {
                return _termsOfService.CrkindCodeNavigation.CrGroupCodeNavigation.CodeI;
            }
        }

        public string GroupName
        {
            get
            {
                return _termsOfService.CrkindCodeNavigation.CrGroupCodeNavigation.Name;
            }
        }

        public bool OurService
        {
            get
            {
                return _termsOfService.OurService;
            }
            set
            {
                _termsOfService.OurService = value;
            }
        }

        public int CommunityCustId
        {
            get
            {
                return _custCmRight.CmCustId;
            }
            set
            {
                _custCmRight.CmCustId = value;
            }
        }

        public DateTime DateBegin
        {
            get
            {
                return _custCmRight.DateBegin;
            }
            set
            {
                _custCmRight.DateBegin = value;
            }
        }

        public DateTime DateEnd
        {
            get
            {
                return _custCmRight.DateEnd;
            }
            set
            {
                _custCmRight.DateEnd = value;
            }
        }
    }
}
