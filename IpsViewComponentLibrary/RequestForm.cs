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
using Telerik.WinControls;
using License = ipsFormsDesign.Model.License;

namespace IpsViewComponentLibrary
{
    public partial class RequestForm : Telerik.WinControls.UI.RadForm
    {
        private BindingList<ObjectAuthorRightholderBrViewModel> _authorRightholderList;
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

        public RequestForm(
            Customer customer,
            ConsumerBigRightView bigRightView,
            AnketaDictionaties dictionaties,
            FormType formType = FormType.Create,
            int? licId = null,
            FormMode formMode = FormMode.ForBigRightAdmin)
        {
            InitializeComponent();
            _licId = licId;
            _customer = customer;
            DialogResult = DialogResult.None;
            _formType = formType;
            _formMode = formMode;
            txtWhereTour.Enabled = checkIsTour.Checked;
            lblTour.Enabled = checkIsTour.Checked;

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
            }

            #region BINDING

            if (licId == null)
            {
                bsConsumerBigRightView.DataSource = bigRightView;
                bsLicAgrParam.DataSource = _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseAgrParam;
                bsLicenseBigR.DataSource = _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseBigR;
                bsLicense.DataSource = _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseAgrParam
                    .SingleOrDefault()?.License;
                _percent = dictionaties.relGenrePercent;
                bsObjectRight.DataSource = _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseBigR?.Obj;
                bsClnBusinessPlace.DataSource = _customer.Client.ClnBusinessPlace;
                SetObjectRightData(
                    _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseBigR?.Obj);

                bsDictObjAct.DataSource = dictionaties.objAct;
                bsDictPerformType.DataSource = dictionaties.performType;
                bsDictGenreType.DataSource = dictionaties.genreType.Where(rec => rec.CategoryCode == 6);
                bsDictLanguage.DataSource = dictionaties.language;
            }
            else
            {
                bsConsumerBigRightView.DataSource = bigRightView;
                var licenseAgr = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licId);

                bsLicAgrParam.DataSource = licenseAgr?.LicenseAgrParam;
                bsLicenseBigR.DataSource = licenseAgr?.LicenseBigR;
                bsLicense.DataSource = licenseAgr?.LicenseAgrParam.SingleOrDefault()?.License;
                _percent = dictionaties.relGenrePercent;
                bsObjectRight.DataSource = licenseAgr?.LicenseBigR?.Obj;
                bsClnBusinessPlace.DataSource = _customer.Client.ClnBusinessPlace;
                //ObjectRightService _service = new ObjectRightService();
                var obj = licenseAgr?.LicenseBigR?.Obj;
                SetObjectRightData(obj);

                bsDictObjAct.DataSource = dictionaties.objAct;
                bsDictPerformType.DataSource = dictionaties.performType;
                bsDictGenreType.DataSource = dictionaties.genreType.Where(rec => rec.CategoryCode == 6);
                bsDictLanguage.DataSource = dictionaties.language;
            }

            #endregion
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
                        MusicalDesign = new ObservableListSource<MusicalDesign>()
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
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ddlPlaceName_SelectedValueChanged(object sender, EventArgs e)
        {
            bsClnPlaceHoll.DataSource = _customer.Client.ClnBusinessPlace.SingleOrDefault(rec => rec?.PlaceId == (int?)ddlPlaceName?.SelectedItem?.Value)?.ClnPlaceHoll;
        }

        private void ddlActType_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshGridDataSource();
        }

        private void btnAddAct_Click(object sender, EventArgs e)
        {
            MusicalDesign design = new MusicalDesign
            {
                ActNumb = (int)ddlActType.SelectedItem.Value,
                Duration = new TimeSpan(00, 00, 00, 01),
            };

            var mus = _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseBigR?.MusicalDesign;
            mus?.Add(design);
            AddCompositionForm addCompositionForm = new AddCompositionForm(mus?.LastOrDefault());
            if (addCompositionForm.ShowDialog() != DialogResult.OK)
                mus?.Remove(design);
            else
                RefreshGridDataSource();
        }

        private void RefreshGridDataSource()
        {
            var source = _customer?.Client?.LicenseAgreement?.LastOrDefault()?.LicenseBigR?.MusicalDesign.Where(rec => rec.ActNumb == (int)ddlActType.SelectedValue)?.ToList();
            gvViewActList.DataSource = source;
        }

        private void gvViewActList_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var delItem = e.Row.DataBoundItem as MusicalDesign;
            _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseBigR?.MusicalDesign.Remove(delItem);
            RefreshGridDataSource();
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
            Int32.TryParse(txtActCode.Text, out int actCode);
            var genreType = Convert.ToInt32(ddlGenreType.SelectedValue);

            var rate = _percent.Where(rec => rec.ActCode == actCode).SingleOrDefault(rec => rec.GenreType == genreType)?.Rate;

            txtVinagoroda.Text = rate.ToString();
        }

        public enum FormMode
        {
            ForBigRightAdmin,
            ForSmallRightAdmin,
        }
    }
}
