using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.Common.Editors;
using IpsViewComponentLibrary.Common.Form;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.ObjectRightControls;
using IpsViewComponentLibrary.Utilities;
using License = ipsFormsDesign.Model.License;

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

        private readonly ObjectRightService _objectRightService = ObjectRightService.GetInstance();
        private readonly DialogService _dialogService = new DialogService();
        private readonly BindingList<RegisterItemViewModel> _musicalDesignList = new BindingList<RegisterItemViewModel>();
        private readonly AnketaDictionaties _dictionaties;

        private BindingList<ObjectAuthorRightholderBrViewModel> _authorRightholderList;
        private Customer _customer;
        private LicenseAgreement _licenseAgreement;
        private ObjectRight _objectRight;
        private ScopeOfUseForm _scopeOfUseForm;
        private FormMode _formMode;
        private bool _deleteLicense = true;
        private int? _licId = null;
        private string _validateString = string.Empty;
        private bool isInit = false;

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        public RequestForm(
            Customer customer, 
            ConsumerBigRightView bigRightView, 
            ScopeOfUseForm scopeOfUseForm = ScopeOfUseForm.Create, 
            int? licId = null, 
            FormMode formMode = FormMode.ForBigRightAdmin, 
            ControlRequestOrReferenceType windowType = ControlRequestOrReferenceType.None)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            SetDictionaries();
            Load += Form_Load;

            txtMusicRate.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtVinagoroda.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtActCode.KeyPress += ExtensionUtils.TextBoxNumeric_KeyPressEvent;

            if(IpsGlobal.AnketaDictionaties != null)
                _dictionaties = IpsGlobal.AnketaDictionaties;

            _licId = licId;
            _customer = customer;
            DialogResult = DialogResult.None;
            _scopeOfUseForm = scopeOfUseForm;
            _formMode = formMode;
            txtWhereTour.Enabled = checkIsTour.Checked;
            lblTour.Enabled = checkIsTour.Checked;
            _deleteLicense = scopeOfUseForm == ScopeOfUseForm.Create;
            dtDate.SetUserCalendarSettingsm();

            switch (_scopeOfUseForm)
            {
                case ScopeOfUseForm.Create:
                    ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Short;
                    CreateNewRequest();
                    Text = CreateRequest;
                    dtDate.MinDate = DateTime.Today;
                    break;
                case ScopeOfUseForm.Edit:
                    ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Short;
                    if (windowType == ControlRequestOrReferenceType.Request)
                        Text = EditRequest;
                    if (windowType == ControlRequestOrReferenceType.Reference)
                        Text = EditReference;
                    btnSave.Enabled = true;
                    break;
                case ScopeOfUseForm.View:
                    ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Short;
                    if (windowType == ControlRequestOrReferenceType.Request)
                        Text = ViewRequest;
                    if (windowType == ControlRequestOrReferenceType.Reference)
                        Text = ViewReference;
                    if (windowType == ControlRequestOrReferenceType.None)
                        Text = ViewLicense;
                    btnCancel.Text = CloseButtonText;
                    btnSave.Visible = false;
                    break;
            }

            #region * * * BINDING * * *

            bsDictObjAct.DataSource = _dictionaties.objAct;
            bsDictPerformType.DataSource = _dictionaties.performType;
            bsDictGenreType.DataSource = _dictionaties.genreType.Where(rec => rec.CategoryCode == 6);
            bsDictLanguage.DataSource = _dictionaties.language;

            bsConsumerBigRightView.DataSource = bigRightView;
            bsClnBusinessPlace.DataSource = _customer.Client.ClnBusinessPlace;

            if (licId == null)
            {
                _licenseAgreement = _customer.Client.LicenseAgreement.Last();
                bsLicense.DataSource = _licenseAgreement.LicenseAgrParam.SingleOrDefault()?.License;
            }
            else
            {
                _licenseAgreement = _customer.Client.LicenseAgreement.Single(rec => rec.LicId == licId);
                bsLicense.DataSource = _licenseAgreement.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == _licenseAgreement.LicVersion)?.License;

                SetMusicalDesignData(_licenseAgreement);
                if (_licenseAgreement.LicStatus != 3)
                    panelStatusees.Enabled = false;
            }
            ctrlMusicalDesignList.DataSource = _musicalDesignList;

            bsLicAgrParam.DataSource = _licenseAgreement.LicenseAgrParam;

            var licenseAgrParam = _licenseAgreement.LicenseAgrParam.Single(rec =>rec.LicVersion == _licenseAgreement.LicVersion);
            if (licenseAgrParam.LicenseBigR != null)
            {
                if (licenseAgrParam.LicenseBigR.IsTour == null)
                    licenseAgrParam.LicenseBigR.IsTour = false;
            }
            bsLicenseBigR.DataSource = licenseAgrParam.LicenseBigR;
            
            _objectRight = licenseAgrParam.LicenseBigR?.Obj;
            var rightholderList = _objectRightService.GetDataBr(_objectRight.ObjId).rhList;
            bsObjectRight.DataSource = _objectRight;

            SetObjectRightData(licenseAgrParam.LicenseBigR, rightholderList);

            bsLicenseAgreement.DataSource = _licenseAgreement;
            ctrlMusicalDesignList.ShowDurationUse = false;
            ctrlMusicalDesignList.ShowLinked = false;

            #endregion

            if (GetReadOnly()) // TODO: read only must be a enum
                ReadOnly = true;
            SetControlsVisibility();

            //txtTicketPriceUah.Validating += NumericValidating;

            isInit = true;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            var licenseAgrParam = _licenseAgreement.LicenseAgrParam.Single(rec =>rec.LicVersion == _licenseAgreement.LicVersion);
            
            if (licenseAgrParam.LicenseBigR == null || licenseAgrParam.LicenseBigR.Rate != 0)
                return;

            var rate = _dictionaties.relGenrePercent
                .Where(rec => rec.ActCode == _objectRight.ActCode)
                .SingleOrDefault(rec => rec.GenreType == _objectRight.GenreType)?.Rate;

            licenseAgrParam.LicenseBigR.Rate = rate;
            bsLicenseBigR.ResetBindings(false);
        }

        private void SetDictionaries()
        {
            ddlState.SetDataSource(IpsGlobal.AnketaDictionaties.licenseType);
            ddlStatus.SetDataSource(IpsGlobal.AnketaDictionaties.agreementStatus);
        }

        private bool GetReadOnly()
        {
            if (_formMode == FormMode.ForSmallRightAdmin)
            {
                if (_licenseAgreement.LicType == (int)LicenseTypes.Bid && _licenseAgreement.LicStatus == (int)AgreementStatuses.OnNegotiation)
                {
                    return false;
                }
                else if (_licenseAgreement.LicType == (int)LicenseTypes.Notice && _licenseAgreement.LicStatus == (int)AgreementStatuses.OnNegotiation)
                {
                    return false;
                }
            }

            if (_formMode == FormMode.ForBigRightAdmin)
            {
                if (_licenseAgreement.LicType == (int)LicenseTypes.Bid && (_licenseAgreement.LicStatus == (int)AgreementStatuses.NotAccepted || _licenseAgreement.LicStatus == (int)AgreementStatuses.Canceled))
                {
                    return false;
                }
                else if (_licenseAgreement.LicType == (int)LicenseTypes.Notice && (_licenseAgreement.LicStatus == (int)AgreementStatuses.NotAccepted || _licenseAgreement.LicStatus == (int)AgreementStatuses.Canceled || _licenseAgreement.LicStatus == (int)AgreementStatuses.Active))
                {
                    return false;
                }
            }

            return true;
        }

        private void SetControlsVisibility()
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

        private void SetMusicalDesignData(LicenseAgreement licenseAgreement)
        {
            var licenseAgrParam = licenseAgreement.LicenseAgrParam.Single(rec => rec.LicVersion == _licenseAgreement.LicVersion);
            foreach (var m in licenseAgrParam.LicenseBigR.MusicalDesign)
            {
                _musicalDesignList.Add(new RegisterItemViewModel(m));
            }
        }

        private void ParseAuthors()
        {
            // map from single table to Authors, Copyright, LicAuthorBr and WorkRh tables
            _objectRight.Authors.Clear();
            _objectRight.CopyRight.Clear();

            var licenseBigR = (LicenseBigR) bsLicenseBigR.DataSource;

            foreach (var authorRightholder in _authorRightholderList)
            {
                if(string.IsNullOrEmpty(authorRightholder.Author.AuthorName))
                    continue;

                _objectRight.AddObjectBrAuthorRightholder(authorRightholder);

                var licAuthorBr = licenseBigR.LicAuthorBr.FirstOrDefault(rec => rec.CRightId == authorRightholder.CopyRight.CRightId);
                if (licAuthorBr == null)
                {
                    licenseBigR.LicAuthorBr.Add(new LicAuthorBr
                    {
                        CRightId = authorRightholder.CopyRight.CRightId,
                        CustIdRh = authorRightholder.CopyRight.CustId,
                        LicId = _licId.Value,
                        LicVersion = 1,
                        PrepayType = authorRightholder.LicAuthorBr.PrepayType,
                        PrepaySum = authorRightholder.LicAuthorBr.PrepaySum,
                        R030 = authorRightholder.LicAuthorBr.R030,
                    });
                }
                else
                {
                    // redundant 
                    // binding work
                    //licAuthorBr.PrepayType = authorRightholder.LicAuthorBr.PrepayType;
                    //licAuthorBr.PrepaySum = authorRightholder.LicAuthorBr.PrepaySum;
                    //licAuthorBr.R030 = authorRightholder.LicAuthorBr.R030;
                }

                //authorRightholder.LicAuthorBr;
                //licAuthorBr.Add();
            }
        }

        private void ParseMusicalDisign()
        {
            LicenseAgreement licenseAgreement = null;
            if (_licId == null)
            {
                licenseAgreement = _customer.Client.LicenseAgreement.LastOrDefault();
                if (licenseAgreement == null)
                    return;
            }
            else
            {
                licenseAgreement = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == _licId);
                if (licenseAgreement == null)
                    return;
            }

            var licenseAgrParam = _licenseAgreement.LicenseAgrParam.Single(rec =>rec.LicVersion == _licenseAgreement.LicVersion);

            licenseAgrParam.LicenseBigR.MusicalDesign.Clear();
            //if(_musicalDesignList.Any())
            foreach (var item in _musicalDesignList)
            {
                if(!AuditMusicalDesignObject(item))
                    continue;

                var musicalDesign = new MusicalDesign
                {
                    MdId = item.MdId,
                    LicId = item.LicId,
                    Objid = item.ObjId,
                    ObjName = item.ItemName,
                    NameSinger = item.Performer,
                    NameMusician = item.AuthorMusic,
                    Duration = item.DurationItem,
                    NumbPerfom = item.CountUse,
                    AuthorText = item.AuthorText,
                    //LicVersion = rvm.LicVersion,
                };

                if (_licId.HasValue)
                {
                    musicalDesign.LicId = licenseAgreement.LicId;
                    //musicalDesign.LicVersion = licenseAgreement.LicVersion;
                }

                licenseAgrParam.LicenseBigR.MusicalDesign.Add(musicalDesign);
            }
        }

        /// <summary>
        /// Перевірка об'єкта на наявність хоча б однї необхідної властивості для збереження цього об'єкта.
        /// True - об'єкт можна записати, False - об'єкт не містить необхідних для запису даних.
        /// </summary>
        /// <param name="item">Об'єкт музичного оформлення</param>
        /// <returns>Результат перевірки об'єкта</returns>
        private bool AuditMusicalDesignObject(RegisterItemViewModel item)
        {
            return !(string.IsNullOrEmpty(item.AuthorMusic)
                  && string.IsNullOrEmpty(item.AuthorText)
                  && string.IsNullOrEmpty(item.Performer)
                  && string.IsNullOrEmpty(item.ItemName)
                  && item.CountUse == null
                  && item.DurationItem == null);
        }

        private void SetObjectRightData(LicenseBigR licenseBigR, IList<ViewCustomer> rightholderList = null)
        {
            // map Authors, Copyright, LicAuthorBr and WorkRh tables into single table
            _authorRightholderList = new BindingList<ObjectAuthorRightholderBrViewModel>(licenseBigR.GetObjectBrAuthorRightholderList(rightholderList));

            ctrlAuthorRightholderList.DataSource = _authorRightholderList;
        }

        /// <summary>
        /// Створити нову заявку
        /// </summary>
        private void CreateNewRequest()
        {
            _licenseAgreement = new LicenseAgreement
            {
                LicClass = 2,
                CustId = _customer.CustId,
                LicVersion = 1,
                LicType = 2,
                LicStatus = 0,
                LicCode = 10,
                AgrId = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicClass == 1 && rec.LicStatus == 2)?.AgrId ?? default(int),
                LicenseAgrParam = new ObservableListSource<LicenseAgrParam>
                {
                    new LicenseAgrParam
                    {
                        LicVersion = 1,
                        LicStatus = 0,
                        LicDate = DateTime.Today,
                        License = new ObservableListSource<License>
                        {
                            new License
                            {
                                PlaceId = _customer.Client.ClnBusinessPlace.FirstOrDefault()?.PlaceId,
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
                    }
                },
            };
            _customer.Client.LicenseAgreement.Add(_licenseAgreement);
        }

        private void CheckIsTour_CheckStateChanged(object sender, EventArgs e)
        {
            txtWhereTour.Enabled = checkIsTour.Checked;
            lblTour.Enabled = checkIsTour.Checked;
        }

        private void RequestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_deleteLicense)
            {
                if (MessageBox.Show("Вийти без збереження?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    _customer.Client.LicenseAgreement.Remove(_licenseAgreement);
                else
                    e.Cancel = true;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
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

            _deleteLicense = false;
            ParseAuthors();
            ParseMusicalDisign();
            int?[] checkInt =  { 4, 5, 7 };
            var GenLic = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicClass == 1 && !checkInt.Contains(rec.LicStatus));
            if(GenLic != null && _licenseAgreement.AgrId != GenLic.AgrId )
            {
                _licenseAgreement.AgrId = GenLic.AgrId;// прив'язка  до ген. угоди
            }
            DialogResult = DialogResult.OK;
        }

        private void DdlPlaceName_SelectedValueChanged(object sender, EventArgs e)
        {
            bsClnPlaceHoll.DataSource = _customer.Client.ClnBusinessPlace.SingleOrDefault(rec => rec?.PlaceId == (int?)ddlPlaceName?.SelectedItem?.Value)?.ClnPlaceHoll;
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
                _objectRight.ActCode = 3;
                bsObjectRight.ResetBindings(false);
            }
            if (val <= 0)
            {
                _objectRight.ActCode = 1;
                bsObjectRight.ResetBindings(false);
            }

            UpdateGenrePersent(true);
        }

        private void GenrePersent_UpdateNeed(object sender, EventArgs e)
        {
            UpdateGenrePersent(false);
        }

        private void UpdateGenrePersent( bool isTxtActCodeChanged )
        {

            if (isInit && int.TryParse(txtActCode.Text, out int actCode))
            {
                if (ddlGenreType.SelectedValue == null)
                    return;

                var genreType = Convert.ToInt32(ddlGenreType.SelectedValue);

                var licenseAgrParam = _licenseAgreement.LicenseAgrParam.Single(rec => rec.LicVersion == _licenseAgreement.LicVersion);

                if (genreType == licenseAgrParam.LicenseBigR.Obj.GenreType && !isTxtActCodeChanged)
                    return;


                var rate = _dictionaties.relGenrePercent.Where(rec => rec.ActCode == actCode).SingleOrDefault(rec => rec.GenreType == genreType)?.Rate;
                if (licenseAgrParam.LicenseBigR?.Rate == rate)
                    return;

                if (licenseAgrParam?.LicenseBigR != null)
                    licenseAgrParam.LicenseBigR.Rate = rate;

                bsLicenseBigR.ResetBindings(false);
            }
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

        // дозвіл на видачу ліцензії
        private void BtnSetActiveStatus_Click(object sender, EventArgs e)
        {
            if (_licenseAgreement.LicType == 3) // Довідка
            {
                bool isValid = true;
                string errText = string.Empty;
                ctrlAuthorRightholderList.ResetErrorText();
                ctrlMusicalDesignList.ResetErrorText();

                if (!ValidateMinRewardAndTotalRate() || !ValidateAllSetPogodgeno() || !ValidateMusicalDesign())
                {
                    isValid = false;
                    errText = _validateString;
                }

                if (!isValid)
                {
                    MessageBox.Show(_validateString, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _licenseAgreement.LicStatus = 2;
            _licenseAgreement.LicenseAgrParam.First( rec => rec.LicVersion == _licenseAgreement.LicVersion).LicStatus = 2;
            bsLicAgrParam.ResetCurrentItem();
            panelStatusees.Enabled = false;
            ReadOnly = true;
            ctrlAuthorRightholderList.AllowEditList = false;
            ctrlMusicalDesignList.AllowEditList = false;
            ctrlMusicalDesignList.AllowActionRegisterItem = false;
        }

        // відхилити
        private void BtnSetCanceledStatus_Click(object sender, EventArgs e)
        {
            _licenseAgreement.LicStatus = 5;
            _licenseAgreement.LicenseAgrParam.First(rec => rec.LicVersion == _licenseAgreement.LicVersion).LicStatus = 5;
            bsLicAgrParam.ResetCurrentItem();
            panelStatusees.Enabled = false;
        }

        private void TxtMusicRate_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMusicRate.Text, out int val))
                return;
            
            if (val > 100)
            {
                var licenseAgrParam = _licenseAgreement.LicenseAgrParam.Single(rec =>rec.LicVersion == _licenseAgreement.LicVersion);
                licenseAgrParam.LicenseBigR.RateMusic = 100m;
                
                bsLicenseBigR.ResetBindings(false);
            }
        }

        private void CtrlAuthorRightholderList_CurrentAuthorRightholderChanged(object sender, EventArgs e)
        {
            ValidateMinRewardAndTotalRate();
        }

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

        public enum FormMode
        {
            ForBigRightAdmin,
            ForSmallRightAdmin,
        }

        private void NumericValidating(object sender, CancelEventArgs e)
        {
            string error = "Очікується числове значення";

            var control = (IpsTextBox) sender;
            //if (control.Text)
            //errorProvider.SetError(control, error);
        }
    }
}
