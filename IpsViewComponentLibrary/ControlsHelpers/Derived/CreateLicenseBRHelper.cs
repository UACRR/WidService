using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ControlsHelpers.Base;
using IpsViewComponentLibrary.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;

namespace IpsViewComponentLibrary.ControlsHelpers.Derived
{
    public class CreateLicenseBRHelper : LicenseBRHelper
    {
        private const string SuccessRequestAdd = "Нову завявку додано!";
        private const string ErrorRequestAdd = "Неможливо зберегти нову заявку!";

        public override async Task<bool> SaveAsync()
        {
            ParseAuthors();
            ParseMusicalDisign();

            var service = LicenseBRService.GetInstance();
            var result = await service.CreateLicenseBR(LicenseAgreement);

            MessageShow.ShowInfoByResult(SuccessRequestAdd, ErrorRequestAdd, result.IsSuccess);

            if (result.HasException)
                ShowMessage.ShowError(result.Exception);

            return result.IsSuccess;
        }

        /// <summary>
        /// Створити нову заявку
        /// </summary>
        public void CreateLicenseAgreementTemplate()
        {
            CreateLicenseAgrParam();

            LicenseAgreement = new LicenseAgreement
            {
                LicClass = 2,
                CustId = CustId,
                LicVersion = 1,
                LicType = 2,
                LicStatus = 0,
                LicCode = 10,
                AgrId = AgrId,
                LicenseAgrParam = new ObservableListSource<LicenseAgrParam>
                {
                    LicenseAgrParam
                },
            };
        }

        private void CreateLicenseAgrParam()
        {
            LicenseAgrParam = new LicenseAgrParam
            {
                LicVersion = 1,
                LicStatus = 0,
                LicDate = DateTime.Today,
                License = new ObservableListSource<License>
                {
                    new License
                    {
                        PlaceId = ClnBusinessPlaceList.FirstOrDefault()?.PlaceId,
                        LicVersion = 1,
                    }
                },
                LicenseBigR = new LicenseBigR
                {
                    Obj = new ObjectRight
                    {
                        Status = 0,
                        CategoryCode = 6,
                        ActCode = 1,
                        SpecType = 1,
                        GenreType = 60001,
                    },
                    MusicalDesign = new ObservableListSource<MusicalDesign>(),
                    Rate = default(decimal),
                    LangCode = "uk",
                    PerformType = 1,
                }
            };
        }
    }
}
