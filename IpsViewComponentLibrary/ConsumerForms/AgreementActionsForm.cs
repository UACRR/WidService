using System;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Common.Enums;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public sealed partial class AgreementActionsForm : RadForm
    {
        public AgreementActionsForm(ObservableListSource<ClnBusinessPlace> clnBusinessPlace, LicenseAgreement license, LicenseAgrParam licenseAgrParam, AgreementModifyType agreementModifyType)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            ctrlSaveCancelButtons.SaveClck += CtrlSaveCancelButtons_SaveClck;

            switch (agreementModifyType)
            {
                case AgreementModifyType.CreateNewAgreement:
                    Text = "Додати новий ліцензійний договір";
                    break;
                case AgreementModifyType.CreateAgreementVersion:
                    Text = "Редагувати активний ліцензійний договір";
                    break;
                case AgreementModifyType.CreateAgreementProlongation:
                    Text = "Пролонгувати ліцензійний договір";
                    break;
                case AgreementModifyType.EditAgreementOrVersion:
                    Text = "Редагувати ліцензійний договір";
                    break;
                case AgreementModifyType.EditAgreementProlongation:
                    Text = "Редагувати пролонгований ліцензійний договір";
                    break;
            }

            ctrlAgreementWithPlaces.Rights = TypeRights.SmallRights;
            ctrlAgreementWithPlaces.InitializeObjects(clnBusinessPlace, license, licenseAgrParam, agreementModifyType);
            ctrlAgreementWithPlaces.LicenseEnabled = agreementModifyType == AgreementModifyType.CreateNewAgreement;
        }

        private void CtrlSaveCancelButtons_SaveClck(object sender, EventArgs e)
        {
            ctrlAgreementWithPlaces.UpdatePlaceLicenses();
        }
    }
}
