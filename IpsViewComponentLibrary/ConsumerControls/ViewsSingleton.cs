using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public class ViewsSingleton
    {
        public static ConsumerBigRightView ConsumerBigRightView { get; private set; }
        public static void SetConsumerBigRightView(ConsumerBigRightView view)
        {
            ConsumerBigRightView = view;
        }

        public static List<GeneralAgreementBigRightView> GeneralAgreementBigRightView { get; private set; }
        public static void SetGeneralAgreementBigRightView(List<GeneralAgreementBigRightView> view)
        {
            GeneralAgreementBigRightView = view;
        }

        public static List<LicenseAgreementBigRightView> LicenseAgreementBigRightView { get; private set; }
        public static void SetLicenseAgreementBigRightView(List<LicenseAgreementBigRightView> view)
        {
            LicenseAgreementBigRightView = view;
        }


    }
}
