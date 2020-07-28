using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ControlsHelpers.Base;
using IpsViewComponentLibrary.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;

namespace IpsViewComponentLibrary.ControlsHelpers.Derived
{
    public class UpdateLicenseBRHelper : LicenseBRHelper
    {
        private const string SuccessRequestEdit = "Зміни збережено!";
        private const string ErrorRequestEdit = "Неможливо зберегти зміни!";

        public override async Task<bool> SaveAsync()
        {
            ParseAuthors();
            ParseMusicalDisign();

            var service = LicenseBRService.GetInstance();
            var result = await service.UpdateLicenseBR(LicenseAgreement);

            MessageShow.ShowInfoByResult(SuccessRequestEdit, ErrorRequestEdit, result.IsSuccess);

            if (result.HasException)
                ShowMessage.ShowError(result.Exception);

            return result.IsSuccess;
        }
    }
}
