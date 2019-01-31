using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Presenters
{
    public class UniqueCheckerPresenter : IUniqueChecker
    {
        private RightholderService _rightholderService;

        public UniqueCheckerPresenter(RightholderService rightholderService)
        {
            _rightholderService = rightholderService;
        }

        public UniqueCheckerPresenter()
        {
            _rightholderService = new RightholderService();
        }

        public bool CheckOKPOIsUnique(string okpo)
        {
            return _rightholderService.CheckOkpoExists(okpo) == false;
        }

        public bool CheckIPIIsUnique(string ipi)
        {
            return _rightholderService.CheckIpiExists(ipi) == false; ;
        }
    }
}
