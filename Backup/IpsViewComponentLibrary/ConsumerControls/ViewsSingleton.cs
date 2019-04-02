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

        public static List<RequestsOrReferenceBigRightView> RequestsBigRightView { get; private set; }

        public static void SetRequestsBigRightView(List<RequestsOrReferenceBigRightView> view)
        {
            RequestsBigRightView = view;
        }

        public static List<RequestsOrReferenceBigRightView> ReferenceBigRightView { get; private set; }

        public static void SetReferenceBigRightView(List<RequestsOrReferenceBigRightView> view)
        {
            ReferenceBigRightView = view;
        }

        public static List<RatedListBigRightView> RatedListBigRightView { get; private set; }

        public static void SetRatedListBigRightView(List<RatedListBigRightView> view)
        {
            RatedListBigRightView = view;
        }

        public static List<RatedListSpectacleBigRightView> RatedListSpectacleBigRightView { get; private set; }

        public static void SetRatedListSpectacleBigRightView(List<RatedListSpectacleBigRightView> view)
        {
            RatedListSpectacleBigRightView = view;
        }

        public static List<AuthorsForLicenseBigRightView> AuthorsForLicenseBigRightView { get; private set; }

        public static void SetAuthorsForLicenseBigRightView(List<AuthorsForLicenseBigRightView> view)
        {
            AuthorsForLicenseBigRightView = view;
        }

        public static List<RatedListMusicDesignBigRightView> RatedListMusicDesignBigRightView { get; private set; }

        public static void SetRatedListMusicDesignBigRightView(List<RatedListMusicDesignBigRightView> view)
        {
            RatedListMusicDesignBigRightView = view;
        }
    }
}
