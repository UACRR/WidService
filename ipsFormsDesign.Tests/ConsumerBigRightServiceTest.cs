using System;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class ConsumerBigRightServiceTest
    {
        private ConsumerBigRightService _bigRightService;
        private int id = 1345;

        [TestInitialize]
        public void TestInit()
        {
            _bigRightService = ConsumerBigRightService.GetInstance();
        }

        [TestMethod]
        public void GetData_test()
        {
            var result = _bigRightService.GetData(id);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void getBRView_all_views_test()
        {
            var result = _bigRightService.GetMainBigRightView();
            Assert.IsNotNull(result, "GetMainBigRightView");

            var generalAgreementBigRightViews = _bigRightService.GetBigRightViewByName(typeof(GeneralAgreementBigRightView), "vTSK_1_BRMaster", id).ToListOfType<GeneralAgreementBigRightView>();
            Assert.IsNotNull(generalAgreementBigRightViews, "vTSK_1_BRMaster");

            var licenseAgreementBigRightViews = _bigRightService.GetBigRightViewByName(typeof(LicenseAgreementBigRightView), "vTsk_vBRLicense", id).ToListOfType<LicenseAgreementBigRightView>();
            Assert.IsNotNull(licenseAgreementBigRightViews, "vTsk_vBRLicense");

            var requestsBigRightViews = _bigRightService.GetBigRightViewByName(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRBid", id).ToListOfType<RequestsOrReferenceBigRightView>();
            Assert.IsNotNull(requestsBigRightViews, "vTsk_1_BRBid");

            var referenceBigRightViews = _bigRightService.GetBigRightViewByName(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRNotice", id).ToListOfType<RequestsOrReferenceBigRightView>();
            Assert.IsNotNull(referenceBigRightViews, "vTsk_1_BRNotice");

            var ratedListBigRightViews = _bigRightService.GetBigRightViewByName(typeof(RatedListBigRightView), "vTSK_1_BRRegister", id).ToListOfType<RatedListBigRightView>();
            Assert.IsNotNull(ratedListBigRightViews, "vTSK_1_BRRegister");

            var spectacleBigRightViews = _bigRightService.GetBigRightViewByName(typeof(RatedListSpectacleBigRightView), "vTsk_1_BRAuthorsDistributed", null).ToListOfType<RatedListSpectacleBigRightView>();
            Assert.IsNotNull(spectacleBigRightViews, "vTsk_1_BRAuthorsDistributed");

            var authorsForLicenseBigRightViews = _bigRightService.GetBigRightViewByName(typeof(AuthorsForLicenseBigRightView), "vTsk_1_BRBidAuthors", id).ToListOfType<AuthorsForLicenseBigRightView>();
            Assert.IsNotNull(authorsForLicenseBigRightViews, "vTsk_1_BRBidAuthors");

            var ratedListMusicDesignBigRightViews = _bigRightService.GetBigRightViewByName(typeof(RatedListMusicDesignBigRightView), "vTsk_1_BRMusic", null).ToListOfType<RatedListMusicDesignBigRightView>();
            Assert.IsNotNull(ratedListMusicDesignBigRightViews, "vTsk_1_BRMusic");
        }

        [TestMethod]
        public void GetNewCustomer_template_test()
        {
            var resultCustType_1 = _bigRightService.NewCustomer(1);
            Assert.IsNotNull(resultCustType_1);

            var resultCustType_3 = _bigRightService.NewCustomer(3);
            Assert.IsNotNull(resultCustType_3);
        }

        public void test()
        {
            _bigRightService.GetMainView()
        }
    }
}
