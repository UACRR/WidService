using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.ObjectRightControls;
using IpsViewComponentLibrary.Utilities;
using License = ipsFormsDesign.Model.License;

namespace IpsViewComponentLibrary
{
    public partial class RequestForm : IpsViewComponentLibrary.Common.Form.IpsForm
    {
        private readonly ConsumerService _consumerService = new ConsumerService();
        private readonly ObjectRightService _objectRightService = new ObjectRightService();
        private readonly DialogService _dialogService = new DialogService();

        private BindingList<ObjectAuthorRightholderBrViewModel> _authorRightholderList;
        private BindingList<RegisterItemViewModel> _musicalDesignList = new BindingList<RegisterItemViewModel>();
        private Customer _customer;
        private LicenseAgreement _licenseAgreement;
        private ObjectRight _objectRight;
        private FormType _formType;
        private FormMode _formMode;
        private bool _deleteLicense = true;
        private IList<RelGenrePercent> _percent;
        private int? _licId = null;

        public RequestForm()
        {
            InitializeComponent();
        }

        public RequestForm( Customer customer,
                            MainGridConsumerBigRightView bigRightView,
                            AnketaDictionaties dictionaties,
                            FormType formType = FormType.Create,
                            int? licId = null,
                            FormMode formMode = FormMode.ForBigRightAdmin)
        {
            InitializeComponent();

            SetDictionaries();

            txtMusicRate.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtVinagoroda.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            dictionaties = IpsGlobal.AnketaDictionaties;
            _licId = licId;
            _customer = customer;
            DialogResult = DialogResult.None;
            _formType = formType;
            _formMode = formMode;
            txtWhereTour.Enabled = checkIsTour.Checked;
            lblTour.Enabled = checkIsTour.Checked;
            _deleteLicense = formType == FormType.Create;
            dtDate.SetUserCalendarSettingsm();
            dtDate.MinDate = DateTime.Today;
            switch (_formType)
            {
                case FormType.Create:
                    ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Short;
                    CreateNewRequest();
                    Text = "Створення нової заявки на ліцензію";
                    break;
                case FormType.Edit:
                    ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Short;
                    //ctrlAuthorRightholderList.OnGetWorkRh += CtrlAuthorRightholderList_OnGetWorkRh;
                    Text = "Редагування заявки на ліцезнію";
                    btnSave.Text = "Зберегти редаговану заявку";
                    btnSave.Enabled = true;
                    break;
                case FormType.View:
                    ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Short;
                    Text = "Перегляд ліцензії";
                    btnCancel.Text = "Закрити";
                    break;
            }

            #region BINDING

            if (licId == null)
            {
                bsConsumerBigRightView.DataSource = bigRightView;
                _licenseAgreement = _customer.Client.LicenseAgreement.LastOrDefault();
                bsLicAgrParam.DataSource = _licenseAgreement?.LicenseAgrParam;
                bsLicenseBigR.DataSource = _licenseAgreement?.LicenseBigR;
                bsLicense.DataSource = _licenseAgreement?.LicenseAgrParam
                    .SingleOrDefault()?.License;
                _percent = dictionaties.relGenrePercent;
                bsClnBusinessPlace.DataSource = _customer.Client.ClnBusinessPlace;

                bsDictObjAct.DataSource = dictionaties.objAct;
                bsDictGenreType.DataSource = dictionaties.genreType.Where(rec => rec.CategoryCode == 6);

                bsDictLanguage.DataSource = dictionaties.language;
                bsDictPerformType.DataSource = dictionaties.performType;

                ddlPerformType.SelectedIndex = ddlPerformType.Items.Last.Index;
                ddlPerformType.SelectedIndex = ddlPerformType.Items.First.Index;

                ddlLang.SelectedIndex = ddlLang.Items.Last.Index;
                ddlLang.SelectedIndex = ddlLang.Items.First.Index;
            }
            else
            {
                bsConsumerBigRightView.DataSource = bigRightView;
                _licenseAgreement = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licId);
                bsLicAgrParam.DataSource = _licenseAgreement?.LicenseAgrParam;
                bsLicenseBigR.DataSource = _licenseAgreement?.LicenseBigR;
                bsLicense.DataSource = _licenseAgreement?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == _licenseAgreement.LicVersion)?.License;
                _percent = dictionaties.relGenrePercent;
                bsClnBusinessPlace.DataSource = _customer.Client.ClnBusinessPlace;

                bsDictObjAct.DataSource = dictionaties.objAct;
                bsDictPerformType.DataSource = dictionaties.performType;
                bsDictGenreType.DataSource = dictionaties.genreType.Where(rec => rec.CategoryCode == 6);
                bsDictLanguage.DataSource = dictionaties.language;

                SetMusicalDesignData(_licenseAgreement);
                ctrlMusicalDesignList.DataSource = _musicalDesignList;
                if (_licenseAgreement.LicStatus != 3)
                {
                    panelStatusees.Enabled = false;
                }
            }

            _objectRight = _licenseAgreement?.LicenseBigR?.Obj;
            var rightholderList = _objectRightService.GetDataBr(_objectRight.ObjId).rhList;
            bsObjectRight.DataSource = _objectRight;
            SetObjectRightData(_objectRight, rightholderList);

            bsLicenseAgreement.DataSource = _licenseAgreement;
            ctrlMusicalDesignList.ShowDurationUse = false;
            ctrlMusicalDesignList.ShowLinked = false;

            #endregion

            if (GetReadOnly() == true) // TODO: read only must be a enum
                ReadOnly = true;
            SetControlsVisibility();
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
            foreach (var m in licenseAgreement.LicenseBigR.MusicalDesign)
            {
                _musicalDesignList.Add(new RegisterItemViewModel(m));
            }
        }

        private void CtrlAuthorRightholderList_OnGetWorkRh(WorkRh workRh)
        {
            if (workRh != null)
                bsWorkRh.DataSource = workRh;
        }

        public void ParseAuthors()
        {
            // map from single table to Authors, Copyright, LicAuthorBr and WorkRh tables
            _objectRight.Authors.Clear();
            _objectRight.CopyRight.Clear();

            foreach (var ar in _authorRightholderList)
            {
                _objectRight.AddObjectBrAuthorRightholder(ar);
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

            licenseAgreement.LicenseBigR.MusicalDesign.Clear();
            if(_musicalDesignList.Any())
            foreach (var rvm in _musicalDesignList)
            {
                var musicalDesign = new MusicalDesign
                {
                    MdId = rvm.MdId,
                    LicId = rvm.LicId,
                    Objid = rvm.ObjId,
                    ObjName = rvm.ItemName,
                    NameSinger = rvm.Performer,
                    NameMusician = rvm.AuthorMusic,
                    Duration = rvm.DurationItem,
                    NumbPerfom = rvm.CountUse,
                    AuthorText = rvm.AuthorText,
                    //LicVersion = rvm.LicVersion,
                };

                if (_licId.HasValue)
                {
                    musicalDesign.LicId = licenseAgreement.LicId;
                    //musicalDesign.LicVersion = licenseAgreement.LicVersion;
                }

                licenseAgreement.LicenseBigR.MusicalDesign.Add(musicalDesign);
            }
            else
            {
                var viewModel = ctrlMusicalDesignList.GetDataSource;
                foreach (var item in viewModel)
                {
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
                        //LicVersion = item.LicVersion,
                    };

                    if (_licId.HasValue)
                    {
                        musicalDesign.LicId = licenseAgreement.LicId;
                        //musicalDesign.LicVersion = licenseAgreement.LicVersion;
                    }

                    licenseAgreement.LicenseBigR.MusicalDesign.Add(musicalDesign);
                }
            }
        }

        private void SetObjectRightData(ObjectRight objectRight, IList<ViewCustomer> rightholderList = null)
        {
            // map Authors, Copyright, LicAuthorBr and WorkRh tables into single table
            _authorRightholderList = new BindingList<ObjectAuthorRightholderBrViewModel>(objectRight.GetObjectBrAuthorRightholderList(rightholderList));

            ctrlAuthorRightholderList.DataSource = _authorRightholderList;
        }

        //створення ліцензійного договору
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
                        }
                    }
                },
                LicenseBigR =
                    new LicenseBigR
                    {
                        Obj = new ObjectRight
                        {
                            Status = 0,
                            CategoryCode = 6,
                            ActCode = 1,
                            SpecType = 1,
                            GenreType = 60001
                        },
                        MusicalDesign = new ObservableListSource<MusicalDesign>(),
                        Rate = default(decimal)
                    }
            };
            _customer.Client.LicenseAgreement.Add(_licenseAgreement);
        }

        private void checkIsTour_CheckStateChanged(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_formMode == FormMode.ForSmallRightAdmin && !ValidateMinRewardAndTotalRate())
            {
                var error = errorProvider.GetError(txtVinagoroda);
                if (error == "Сума долей не може перевищувати мінімальну ставку винагороди.")
                {
                    _dialogService.ShowError(this, error);
                    return;
                }
                else
                {
                    _dialogService.ShowMessage(this, error);
                }
            }

            _deleteLicense = false;
            ParseAuthors();
            ParseMusicalDisign();
            var agrid = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicClass == 1 && rec.LicStatus == 2)?.AgrId ?? default(int);
            if(_licenseAgreement.AgrId != agrid)
                _licenseAgreement.AgrId = agrid;// прив'язка  до ген. угоди
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ddlPlaceName_SelectedValueChanged(object sender, EventArgs e)
        {
            bsClnPlaceHoll.DataSource = _customer.Client.ClnBusinessPlace.SingleOrDefault(rec => rec?.PlaceId == (int?)ddlPlaceName?.SelectedItem?.Value)?.ClnPlaceHoll;
        }

        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageView.SelectedPage == pvMusicalArrangement && ReadOnly == false)
                btnSave.Enabled = true;
        }

        private void txtActCode_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtActCode.Text, out int val))
                if (val > 3)
                    txtActCode.Text = "3";
            UpdateGenrePersent();
        }

        private void ddlGenreType_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateGenrePersent();
        }

        private void UpdateGenrePersent()
        {
            if (Int32.TryParse(txtActCode.Text, out int actCode))
            {
                var genreType = Convert.ToInt32(ddlGenreType.SelectedValue);

                var rate = _percent.Where(rec => rec.ActCode == actCode).SingleOrDefault(rec => rec.GenreType == genreType)?.Rate;

                txtVinagoroda.Text = rate.ToString();
                _licenseAgreement.LicenseBigR.Rate = rate;
            }
        }

        public enum FormMode
        {
            ForBigRightAdmin,
            ForSmallRightAdmin,
        }

        private void btnSetActiveStatus_Click(object sender, EventArgs e)
        {
            _licenseAgreement.LicStatus = 2;
            _licenseAgreement.LicenseAgrParam.First().LicStatus = 2;
            bsLicAgrParam.ResetCurrentItem();
            panelStatusees.Enabled = false;
        }

        private void btnSetCanceledStatus_Click(object sender, EventArgs e)
        {
            _licenseAgreement.LicStatus = 5;
            _licenseAgreement.LicenseAgrParam.First().LicStatus = 5;
            bsLicAgrParam.ResetCurrentItem();
            panelStatusees.Enabled = false;
        }

        private void ddlPerformType_Leave(object sender, EventArgs e)
        {
            UpdateGenrePersent();
        }

        private void ddlLang_Leave(object sender, EventArgs e)
        {
            UpdateGenrePersent();
        }

        private void txtMusicRate_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtMusicRate.Text, out int val))
                if (val > 100)
                    txtMusicRate.Text = "100";
        }

        private void ctrlAuthorRightholderList_CurrentAuthorRightholderChanged(object sender, EventArgs e)
        {
            ValidateMinRewardAndTotalRate();
        }

        private bool ValidateMinRewardAndTotalRate()
        {
            var errorText = "";

            if (int.TryParse(txtVinagoroda.Text, out int minReward))
            {
                var tolalRate = _objectRight.CopyRight.GetTotalRoleRate();


                if (tolalRate > minReward)
                    errorText = "Сума долей не може перевищувати мінімальну ставку винагороди.";
                else if (tolalRate < minReward)
                    errorText = "Сума долей повинна співпадати з мінімальною ставкою винагороди.";
                else
                    errorText = "";

                errorProvider.SetError(txtVinagoroda, errorText);
                ctrlAuthorRightholderList.RoleRateErrorText = errorText;
            }

            return errorText == "";
        }
    }
}
