using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.ObjectRightControls;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;
using License = ipsFormsDesign.Model.License;

namespace IpsViewComponentLibrary
{
    public partial class RequestForm : Telerik.WinControls.UI.RadForm
    {
        private readonly ConsumerService _consumerService = new ConsumerService();
        private readonly DialogService _dialogService = new DialogService();

        private BindingList<ObjectAuthorRightholderBrViewModel> _authorRightholderList;
        private BindingList<RegisterItemViewModel> _musicalDesignList = new BindingList<RegisterItemViewModel>();
        private ObjectAuthorRightholderBrViewModel _brViewModel;
        private Customer _customer;
        private LicenseAgreement _licenseAgreement;
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
                            ConsumerBigRightView bigRightView,
                            AnketaDictionaties dictionaties,
                            FormType formType = FormType.Create,
                            int? licId = null,
                            FormMode formMode = FormMode.ForBigRightAdmin)
        {
            InitializeComponent();

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
            if (_formType == FormType.Create)
            {
                ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Short;
                CreateNewRequest();
                Text = "Створення нової заявки на ліцензію";

            }
            else if (_formType == FormType.Edit)
            {
                ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Short;
                //ctrlAuthorRightholderList.OnGetWorkRh += CtrlAuthorRightholderList_OnGetWorkRh;
                Text = "Редагування заявки на ліцезнію";
                btnSave.Text = "Зберегти редаговану заявку";
                btnSave.Enabled = true;
            }

            if (_formMode == FormMode.ForSmallRightAdmin)
            {
                ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Full;

                ctrlMusicalDesignList.AllowEditList = false;
                ctrlMusicalDesignList.ShowObjectInfo = true;
                ctrlMusicalDesignList.AllowFindCommand = true;
                ctrlMusicalDesignList.AllowLinkCommand = true;
                ctrlMusicalDesignList.AllowShowObjectCommand = true;
                ctrlMusicalDesignList.AllowUnlinkCommand = true;
                ctrlMusicalDesignList.AllowCreateObjectCommand = true;

                panelStatusees.Visible = true;
            }
            else if (_formMode == FormMode.ForBigRightAdmin)
            {
                ctrlAuthorRightholderList.ListMode = AuthorRightholderBrListMode.Short;

                ctrlMusicalDesignList.AllowEditList = true;
                ctrlMusicalDesignList.ShowObjectInfo = false;
                ctrlMusicalDesignList.AllowFindCommand = false;
                ctrlMusicalDesignList.AllowLinkCommand = false;
                ctrlMusicalDesignList.AllowShowObjectCommand = false;
                ctrlMusicalDesignList.AllowUnlinkCommand = false;
                ctrlMusicalDesignList.AllowCreateObjectCommand = false;

                panelStatusees.Visible = false;
            }

            #region BINDING

            if (licId == null)
            {
                bsConsumerBigRightView.DataSource = bigRightView;
                _licenseAgreement = _customer.Client.LicenseAgreement.LastOrDefault();
                if (_licenseAgreement != null)
                    _licenseAgreement.AgrId = bigRightView.AgrId;
                bsLicAgrParam.DataSource = _licenseAgreement?.LicenseAgrParam;
                bsLicenseBigR.DataSource = _licenseAgreement?.LicenseBigR;
                bsLicense.DataSource = _licenseAgreement?.LicenseAgrParam
                    .SingleOrDefault()?.License;
                _percent = dictionaties.relGenrePercent;
                bsObjectRight.DataSource = _licenseAgreement?.LicenseBigR?.Obj;
                bsClnBusinessPlace.DataSource = _customer.Client.ClnBusinessPlace;
                SetObjectRightData(_licenseAgreement?.LicenseBigR?.Obj);

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
                bsLicense.DataSource = _licenseAgreement?.LicenseAgrParam.SingleOrDefault()?.License;
                _percent = dictionaties.relGenrePercent;
                bsObjectRight.DataSource = _licenseAgreement?.LicenseBigR?.Obj;
                bsClnBusinessPlace.DataSource = _customer.Client.ClnBusinessPlace;
                //ObjectRightService _service = new ObjectRightService();
                var obj = _licenseAgreement?.LicenseBigR?.Obj;
                SetObjectRightData(obj);

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


            #endregion
        }

        private void SetMusicalDesignData(LicenseAgreement licenseAgreement)
        {
            foreach (var m in licenseAgreement.LicenseBigR.MusicalDesign)
            {
                _musicalDesignList.Add(new RegisterItemViewModel(m));
            }
        }

        private void SetVisible()
        {
            lblComCl.Visible = _formType == FormType.Edit;
            lblComRh.Visible = _formType == FormType.Edit;
            txtCommentCl.Visible = _formType == FormType.Edit;
            txtCommentRh.Visible = _formType == FormType.Edit;
        }

        private void CtrlAuthorRightholderList_OnGetWorkRh(WorkRh workRh)
        {
            if (workRh != null)
                bsWorkRh.DataSource = workRh;
        }

        public void ParseAuthors()
        {
            ObjectRight objectRight = null;
            if (_licId == null)
            {
                objectRight = _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseBigR?.Obj;
                if (objectRight == null)
                    return;
            }
            else
            {
                objectRight = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == _licId)?.LicenseBigR?.Obj;
                if (objectRight == null)
                    return;
            }

            // map from single table to Authors, Copyright, LicAuthorBr and WorkRh tables
            objectRight.Authors.Clear();
            objectRight.CopyRight.Clear();

            foreach (var ar in _authorRightholderList)
            {
                objectRight.AddObjectBrAuthorRightholder(ar);
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
            var tmpAuthorRightholderList = objectRight.Authors.Select(a =>
                {
                    var foundedCopyright = objectRight.CopyRight.FirstOrDefault(c => c.CustId == a.CustId && c.RoleCode == a.RoleCode);
                    var foundedRightholder = rightholderList?.FirstOrDefault(r => r.custId == a.CustId);

                    return new ObjectAuthorRightholderBrViewModel
                    {
                        Country = foundedRightholder?.Country,
                        InnerCode = foundedRightholder?.InnerCode,
                        Author = a,
                        CopyRight = foundedCopyright,
                        LicAuthorBr = foundedCopyright?.LicAuthorBr ?? new LicAuthorBr(),
                        WorkRh = foundedCopyright?.WorkRh ?? new WorkRh(),
                    };
                })
                .ToList();

            _authorRightholderList = new BindingList<ObjectAuthorRightholderBrViewModel>(tmpAuthorRightholderList);

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
            _deleteLicense = false;
            ParseAuthors();
            ParseMusicalDisign();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ddlPlaceName_SelectedValueChanged(object sender, EventArgs e)
        {
            bsClnPlaceHoll.DataSource = _customer.Client.ClnBusinessPlace.SingleOrDefault(rec => rec?.PlaceId == (int?)ddlPlaceName?.SelectedItem?.Value)?.ClnPlaceHoll;
        }

        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageView.SelectedPage == pvMusicalArrangement)
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
            var result = _consumerService.SetLicAgreementStatus(_licenseAgreement, _licenseAgreement.LicVersion.Value, 2);

            if (result)
            {
                _dialogService.ShowMessage(this, "Переведено до статусу: Активний.");
                panelStatusees.Enabled = false;
            }
            else
                _dialogService.ShowError(this, "Не вдалося змінити статус.");
        }

        private void btnSetCanceledStatus_Click(object sender, EventArgs e)
        {
            var result = _consumerService.SetLicAgreementStatus(_licenseAgreement, _licenseAgreement.LicVersion.Value, 5);

            if (result)
            {
                _dialogService.ShowMessage(this, "Переведено до статусу: Відхилений.");
                panelStatusees.Enabled = false;
            }
            else
                _dialogService.ShowError(this, "Не вдалося змінити статус.");
        }

        private void ddlPerformType_Leave(object sender, EventArgs e)
        {
            UpdateGenrePersent();
        }

        private void ddlLang_Leave(object sender, EventArgs e)
        {
            UpdateGenrePersent();
        }
    }
}
