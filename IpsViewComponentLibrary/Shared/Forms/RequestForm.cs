using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.Common.Form;
using IpsViewComponentLibrary.ConsumerControls;
using IpsViewComponentLibrary.ControlsHelpers.Base;
using IpsViewComponentLibrary.ControlsHelpers.Derived;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.ObjectRightControls;
using IpsViewComponentLibrary.Utilities;
using IPSViewComponentLibraryWPF.IPSExtensions;

namespace IpsViewComponentLibrary.Shared.Forms
{
    public partial class RequestForm : IpsForm
    {
        private const string ViewRequest = "Перегляд заявки";
        private const string ViewReference = "Перегляд довідки";
        private const string ViewLicense = "Перегляд ліцензії";

        private const string CreateRequest = "Створення нової заявки на ліцензію";
        private const string EditRequest = "Редагування заявки на ліцезнію";
        private const string EditReference = "Редагування довідки";

        private const string CloseButtonText = "Закрити";

        private readonly DialogService _dialogService = new DialogService();
        
        private static LicenseBRHelper _helper;

        private FormMode _formMode;
        private bool _mayBeUnsavedChanges;
        private string _validateString = string.Empty;
        private bool isInit;

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private RequestForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            NoChangeReadOnlyControls.AddRange(new Control[]
            {
                ddlState,
                ddlStatus,
                panelClient,
                txtAddress,
                txtValuePlace,
            });

            ddlState.SetDataSource(IpsGlobal.AnketaDictionaties.licenseType);
            ddlStatus.SetDataSource(IpsGlobal.AnketaDictionaties.agreementStatus);

            Load += Form_Load;

            txtMusicRate.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtVinagoroda.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtActCode.KeyPress += ExtensionUtils.TextBoxNumeric_KeyPressEvent;
            
            ctrlAuthorRightholderList.CurrentAuthorRightholderChanged += (o,e) => ValidateMinRewardAndTotalRate();

            // оновити % при зміні жанру
            ddlGenreType.SelectedValueChanged += (o,e) => UpdateGenrePersent(false);

            txtWhereTour.Enabled = checkIsTour.Checked;
            lblTour.Enabled = checkIsTour.Checked;

            dtDate.SetUserCalendarSettings();

            // стислий вигляд списку авторів
            ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Short;

            bsDictObjAct.DataSource = IpsGlobal.AnketaDictionaties.objAct;
            bsDictPerformType.DataSource = IpsGlobal.AnketaDictionaties.performType;
            bsDictGenreType.DataSource = IpsGlobal.AnketaDictionaties.genreType.Where(rec => rec.CategoryCode == 6);
            bsDictLanguage.DataSource = IpsGlobal.AnketaDictionaties.language;

            bsConsumerBigRightView.DataSource = ViewsSingleton.ConsumerBigRightView;
            bsClnBusinessPlace.DataSource = IpsGlobal.CurrentClient.ClnBusinessPlaceCollection;
        }

        public static RequestForm CreateLicenseBRForm(FormMode formMode = FormMode.ForBigRightAdmin)
        {
            _helper = new CreateLicenseBRHelper
            {
                CustId = IpsGlobal.CurrentClient.CustId,
                AgrId = IpsGlobal.CurrentClient.AgrId,
                ClnBusinessPlaceList = IpsGlobal.CurrentClient.ClnBusinessPlaceCollection,
            };

            ((CreateLicenseBRHelper)_helper).CreateLicenseAgreementTemplate();

            var form = new RequestForm
            {
                Text = CreateRequest, 
                _formMode = formMode,
                _mayBeUnsavedChanges = true,
            };

            CompleteBinding(form);

            return form;
        }

        public static RequestForm UpdateLicenseBRForm(LicenseAgreement licenseAgreement, FormMode formMode = FormMode.ForBigRightAdmin)
        {
            _helper = new UpdateLicenseBRHelper
            {
                CustId = IpsGlobal.CurrentClient.CustId,
                AgrId = IpsGlobal.CurrentClient.AgrId,
                ClnBusinessPlaceList = IpsGlobal.CurrentClient.ClnBusinessPlaceCollection,
                LicenseAgreement = licenseAgreement,
            };

            string text = string.Empty;
            switch (licenseAgreement.LicType)
            {
                case 2:
                    text = EditRequest;
                    break;
                case 3:
                    text = EditReference;
                    break;
            }

            var form = new RequestForm
            {
                _formMode = formMode,
                _mayBeUnsavedChanges = true,
                Text = text,
            };

            form.btnSave.Enabled = true;

            CompleteBinding(form);

            return form;
        }

        public static RequestForm ViewLicenseBRForm(LicenseAgreement licenseAgreement, FormMode formMode = FormMode.ForBigRightAdmin)
        {
            _helper = new ViewLicenseBRHelper
            {
                CustId = IpsGlobal.CurrentClient.CustId,
                AgrId = IpsGlobal.CurrentClient.AgrId,
                ClnBusinessPlaceList = IpsGlobal.CurrentClient.ClnBusinessPlaceCollection,
                LicenseAgreement = licenseAgreement,
            };

            string text = string.Empty;
            switch (licenseAgreement.LicType)
            {
                case 1:
                    text = ViewLicense;
                    break;
                case 2:
                    text = ViewRequest;
                    break;
                case 3:
                    text = ViewReference;
                    break;
            }

            var form = new RequestForm
            {
                _formMode = formMode,
                Text = text,
            };

            form.btnSave.Visible = false;
            form.btnCancel.Text = CloseButtonText;

            CompleteBinding(form);
            
            return form;
        }

        private static void CompleteBinding(RequestForm form)
        {

            form.dtDate.MinDate = DateTime.Today;

            form.bsLicense.DataSource = _helper.LicenseAgrParam.License;
            form.bsLicAgrParam.DataSource = _helper.LicenseAgrParam;

            _helper.MusicalDesignList = new BindingList<RegisterItemViewModel>();

            foreach (var m in _helper.LicenseAgrParam.LicenseBigR.MusicalDesign)
                _helper.MusicalDesignList.Add(new RegisterItemViewModel(m));

            form.ctrlMusicalDesignList.DataSource = _helper.MusicalDesignList;

            // it is new license with status 0, always true...
            if (_helper.LicenseAgreement.LicStatus != 3)
                form.panelStatusees.Enabled = false;

            if (_helper.LicenseAgrParam.LicenseBigR.IsTour == null)
                _helper.LicenseAgrParam.LicenseBigR.IsTour = false;

            form.bsLicenseBigR.DataSource = _helper.LicenseAgrParam.LicenseBigR;

            var rightholderList = ObjectRightService.GetInstance().GetDataBr(_helper.ObjectRight.ObjId).rhList;
            form.bsObjectRight.DataSource = _helper.ObjectRight;

            // map Authors, Copyright, LicAuthorBr and WorkRh tables into single table
            var list = _helper.LicenseAgrParam.LicenseBigR.GetObjectBrAuthorRightholderList(rightholderList);
            _helper.AuthorRightholderBrList = list;
            form.ctrlAuthorRightholderList.DataSource = new BindingList<ObjectAuthorRightholderBrViewModel>(list);

            form.bsLicenseAgreement.DataSource = _helper.LicenseAgreement;
            form.ctrlMusicalDesignList.ShowDurationUse = false;
            form.ctrlMusicalDesignList.ShowLinked = false;

            form.ChangeReadOnly();
            form.ChangeControlsVisibility();

            form.isInit = true;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            var licenseBigR = _helper.LicenseAgrParam.LicenseBigR;

            if (licenseBigR == null || licenseBigR.Rate != 0)
                return;

            var rate = IpsGlobal.AnketaDictionaties.relGenrePercent
                .SingleOrDefault(rec => rec.ActCode == _helper.ObjectRight.ActCode && rec.GenreType == _helper.ObjectRight.GenreType)?.Rate;

            licenseBigR.Rate = rate;
            bsLicenseBigR.ResetBindings(false);
        }

        private void RequestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_mayBeUnsavedChanges && ShowMessage.ConfirmAction("Вийти без збереження?") != MessageBoxResult.Yes)
                e.Cancel = true;
        }

        /// <summary>
        /// Зберегти зміни
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (_formMode == FormMode.ForSmallRightAdmin && !ValidateMinRewardAndTotalRate())
            {
                var error = errorProvider.GetError(txtVinagoroda);
                if (error == "Сума долей не може перевищувати мінімальну ставку винагороди.")
                {
                    _dialogService.ShowError(this, error);
                    // return; // MED-742 Патлякевич
                }
                else
                {
                    _dialogService.ShowMessage(this, error);
                    // return; // return; MED-742 Патлякевич
                }
            }

            var result = await _helper.SaveAsync();

            if (result)
            {
                _mayBeUnsavedChanges = false;
                DialogResult = DialogResult.OK;
            }
        }

        #region * * * кнопки зміну статусу ліцензії * * *

        /// <summary>
        /// Дозвіл на видачу ліцензії
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetActiveStatus_Click(object sender, EventArgs e)
        {
            if (_helper.LicenseAgreement.LicType == 3) // Довідка
            {
                bool isValid = true;
                ctrlAuthorRightholderList.ResetErrorText();
                ctrlMusicalDesignList.ResetErrorText();

                if (!ValidateMinRewardAndTotalRate() || !ValidateAllSetPogodgeno() || !ValidateMusicalDesign())
                {
                    isValid = false;
                }

                if (!isValid)
                {
                    ShowMessage.ShowError(_validateString);
                    return;
                }
            }

            _helper.LicenseAgreement.LicStatus = 2;
            _helper.LicenseAgrParam.LicStatus = 2;
            bsLicAgrParam.ResetCurrentItem();
            panelStatusees.Enabled = false;
            ReadOnly = true;
            ctrlAuthorRightholderList.AllowEditList = false;
            ctrlMusicalDesignList.AllowEditList = false;
            ctrlMusicalDesignList.AllowActionRegisterItem = false;
        }

        /// <summary>
        /// Перевірка сум долей
        /// </summary>
        /// <returns></returns>
        private bool ValidateMinRewardAndTotalRate()
        {
            var errorText = "";

            if (decimal.TryParse(txtVinagoroda.Text, out decimal minReward))
            {
                var tolalRate = ctrlAuthorRightholderList.GetAuthorRates();


                if (tolalRate > minReward)
                    errorText = "Сума долей не може перевищувати мінімальну ставку винагороди.";
                else if (tolalRate < minReward)
                    errorText = "Сума долей повинна співпадати з мінімальною ставкою винагороди.";
                else
                    errorText = "";

                _validateString = errorText;
                errorProvider.SetError(txtVinagoroda, errorText);
                ctrlAuthorRightholderList.RoleRateErrorText = errorText;
            }

            return errorText == "";
        }

        /// <summary>
        /// Перевірка на підтверження права
        /// </summary>
        /// <returns></returns>
        private bool ValidateAllSetPogodgeno()
        {
            bool isValid = ctrlAuthorRightholderList.GetCountNoPogod() == 0;

            if (!isValid)
            {
                _validateString = "Є непогоджені Правовласником права";
                ctrlAuthorRightholderList.SetInvalidProlong(_validateString);
            }
            return isValid;
        }

        /// <summary>
        /// Перевірка на прив'язку Мужичного оформлення
        /// </summary>
        /// <returns></returns>
        private bool ValidateMusicalDesign()
        {
            bool isValid = ctrlMusicalDesignList.GetCountUnlink() == 0;
            if (!isValid)
            {
                _validateString = "Є твори 'Збірної музики' не прив'язані до об'єкту права";
                pageView.SelectedPage = pvMusicalArrangement;
                ctrlMusicalDesignList.SetErrorForUnlinkRows(_validateString);
            }
            return isValid;
        }

        /// <summary>
        /// Відхилити
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetCanceledStatus_Click(object sender, EventArgs e)
        {
            _helper.LicenseAgreement.LicStatus = 5;
            _helper.LicenseAgrParam.LicStatus = 5;
            bsLicAgrParam.ResetCurrentItem();
            panelStatusees.Enabled = false;
        }

        #endregion

        private void ChangeReadOnly()
        {
            bool isReadOnly = true;

            // LicStatus from AgreementStatus dictionary

            if (_formMode == FormMode.ForSmallRightAdmin)
            {
                if (_helper.LicenseAgreement.LicType == (int)LicenseTypes.Bid && _helper.LicenseAgreement.LicStatus == 3)
                {
                    isReadOnly = false;
                }
                else if (_helper.LicenseAgreement.LicType == (int)LicenseTypes.Notice && _helper.LicenseAgreement.LicStatus == 3)
                {
                    isReadOnly = false;
                }
            }

            if (_formMode == FormMode.ForBigRightAdmin)
            {
                if (_helper.LicenseAgreement.LicType == (int)LicenseTypes.Bid && (_helper.LicenseAgreement.LicStatus == 0 || _helper.LicenseAgreement.LicStatus == 5))
                {
                    isReadOnly = false;
                }
                else if (_helper.LicenseAgreement.LicType == (int)LicenseTypes.Notice && (_helper.LicenseAgreement.LicStatus == 0 || _helper.LicenseAgreement.LicStatus == 5 || _helper.LicenseAgreement.LicStatus == 2))
                {
                    isReadOnly = false;
                }
            }

            ReadOnly = isReadOnly;
        }

        private void ChangeControlsVisibility()
        {
            ctrlAuthorRightholderList.AllowEditList = !ReadOnly;

            btnSave.Visible = !ReadOnly;

            if (_formMode == FormMode.ForSmallRightAdmin)
            {
                ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Full;

                ctrlMusicalDesignList.AllowEditList = false;
                ctrlMusicalDesignList.AllowCreateObjectCommand = !ReadOnly;
                ctrlMusicalDesignList.AllowFindCommand = !ReadOnly;
                ctrlMusicalDesignList.AllowLinkCommand = !ReadOnly;
                ctrlMusicalDesignList.AllowUnlinkCommand = !ReadOnly;
                ctrlMusicalDesignList.ShowObjectInfo = true;
                ctrlMusicalDesignList.AllowShowObjectCommand = true;
                ctrlMusicalDesignList.ShowFilters = true;

                panelStatusees.Visible = !ReadOnly;
            }
            else if (_formMode == FormMode.ForBigRightAdmin)
            {
                ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Short;

                ctrlMusicalDesignList.AllowEditList = !ReadOnly;
                ctrlMusicalDesignList.ShowObjectInfo = false;
                ctrlMusicalDesignList.AllowFindCommand = false;
                ctrlMusicalDesignList.AllowLinkCommand = false;
                ctrlMusicalDesignList.AllowShowObjectCommand = false;
                ctrlMusicalDesignList.AllowUnlinkCommand = false;
                ctrlMusicalDesignList.AllowCreateObjectCommand = false;
                ctrlMusicalDesignList.ShowFilters = false;

                panelStatusees.Visible = false;
            }
        }

        #region * * * events handlers * * *

        private void CheckIsTour_CheckStateChanged(object sender, EventArgs e)
        {
            txtWhereTour.Enabled = checkIsTour.Checked;
            lblTour.Enabled = checkIsTour.Checked;
        }

        private void DdlPlaceName_SelectedValueChanged(object sender, EventArgs e)
        {
            var clnBusinessPlace = _helper.ClnBusinessPlaceList.SingleOrDefault(rec => rec.PlaceId == (int?)ddlPlaceName.SelectedItem?.Value);
            bsClnPlaceHoll.DataSource = clnBusinessPlace?.ClnPlaceHoll;
            //bsClnPlaceHoll.DataSource = _customer.Client.ClnBusinessPlace.SingleOrDefault(rec => rec?.PlaceId == (int?)ddlPlaceName?.SelectedItem?.Value)?.ClnPlaceHoll;
        }

        private void PageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageView.SelectedPage == pvMusicalArrangement && ReadOnly == false)
                btnSave.Enabled = true;
        }

        private void TxtActCode_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtActCode.Text, out int val))
                return;
            if (val > 3)
            {
                _helper.ObjectRight.ActCode = 3;
                bsObjectRight.ResetBindings(false);
            }
            if (val <= 0)
            {
                _helper.ObjectRight.ActCode = 1;
                bsObjectRight.ResetBindings(false);
            }

            UpdateGenrePersent(true);
        }

        private void UpdateGenrePersent( bool isTxtActCodeChanged )
        {
            if (isInit && int.TryParse(txtActCode.Text, out int actCode))
            {
                if (ddlGenreType.SelectedValue == null)
                    return;

                var genreType = Convert.ToInt32(ddlGenreType.SelectedValue);

                if (genreType == _helper.LicenseAgrParam.LicenseBigR.Obj.GenreType && !isTxtActCodeChanged)
                    return;

                var rate = IpsGlobal.AnketaDictionaties.relGenrePercent
                    .SingleOrDefault(rec => rec.ActCode == actCode && rec.GenreType == genreType)?.Rate;
                
                if (_helper.LicenseAgrParam.LicenseBigR?.Rate == rate)
                    return;

                if (_helper.LicenseAgrParam.LicenseBigR != null)
                    _helper.LicenseAgrParam.LicenseBigR.Rate = rate;

                bsLicenseBigR.ResetBindings(false);
            }
        }

        private void TxtMusicRate_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMusicRate.Text, out int val))
                return;
            
            if (val > 100)
            {
                _helper.LicenseAgrParam.LicenseBigR.RateMusic = 100m;
                bsLicenseBigR.ResetBindings(false);
            }
        }

        #endregion

        public enum FormMode
        {
            ForBigRightAdmin,
            ForSmallRightAdmin,
        }
    }
}
