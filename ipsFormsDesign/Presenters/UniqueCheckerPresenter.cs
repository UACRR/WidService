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

        public bool CheckOKPOIsUnique(string okpo, int? custId )
        {
            var normalOkpo = okpo == null ? string.Empty : okpo.Trim();

            if (normalOkpo == string.Empty)
                return true;

            var list = _rightholderService.CheckOkpoExists(okpo);
            // Для нового користувача повинен бути пустий масив
            if ((custId ?? 0) == 0)
                return list.Count() == 0;
            // Для існуючого користувача немає заданого ОКПО для інших користувачів
            return list.Where( rec => rec.CustId != custId ).FirstOrDefault() == null;
        }

        public bool CheckIPIIsUnique(string ipi, int? custId )
        {
            var normalIpi = ipi == null ? string.Empty : ipi.Trim();

            if (normalIpi == string.Empty)
                return true;

            var list = _rightholderService.CheckIpiExists(ipi);

            if ((custId ?? 0) == 0)
                return list.Count() == 0;
            // Для існуючого користувача немає заданого IPI для інших користувачів
            return list.Where(rec => rec.CustId != custId).FirstOrDefault() == null;
        }

        private bool isZeroString( string okpo )
        {
            char[] chars = okpo.ToArray();

            var charGroup = chars.GroupBy(rec => rec).Select(g => new { Name = g.Key, Count = g.Count() }).ToArray();
            if (charGroup.Count() == 1 && charGroup[0].Name == '0')
                return true;

            return false;
        }
        public bool CheckINNIsUnique(string okpo, int? custId )
        {
            var normalOkpo = okpo == null ? string.Empty :okpo.Trim();

            if (normalOkpo == string.Empty)
                return true;

            if (isZeroString(okpo))
                return true;

            return CheckOKPOIsUnique(okpo, custId);
        }

    }
}
