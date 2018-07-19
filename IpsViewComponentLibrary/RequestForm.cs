using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;
using License = ipsFormsDesign.Model.License;

namespace IpsViewComponentLibrary
{
    public partial class RequestForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;
        private LicenseAgreement _licenseAgreement;
        private bool _deleteLicense = true;
        public RequestForm()
        {
            InitializeComponent();
        }
        public RequestForm(Customer customer, ConsumerBigRightView bigRightView, AnketaDictionaties dictionaties)
        {
            InitializeComponent();
            _customer = customer;
            DialogResult = DialogResult.None;
            txtWhereTour.Enabled = checkIsTour.Checked;
            lblTour.Enabled = checkIsTour.Checked;

            dtDate.SetUserCalendarSettingsm();
            dtDate.MinDate = DateTime.Today;

            CreateNewRequest();
            #region BINDING
            bsConsumerBigRightView.DataSource = bigRightView;
            bsLicAgrParam.DataSource = _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseAgrParam;
            bsLicenseBigR.DataSource = _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseBigR;
            bsLicense.DataSource = _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseAgrParam.SingleOrDefault()?.License;
            bsObjectRight.DataSource = _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseBigR.SingleOrDefault()?.Obj;
            bsClnBusinessPlace.DataSource = _customer.Client.ClnBusinessPlace;

            bsDictObjAct.DataSource = dictionaties.objAct;
            bsDictPerformType.DataSource = dictionaties.performType;
            bsDictGenreType.DataSource = dictionaties.genreType;
            bsDictLanguage.DataSource = dictionaties.language;


            #endregion
        }


        private void CreateNewRequest()
        {
            _licenseAgreement = new LicenseAgreement
            {
                CustId = _customer.CustId,
                LicVersion = 1,
                LicType = 2,
                LicStatus = 0,
                LicenseAgrParam = new ObservableListSource<LicenseAgrParam>
                {
                    new LicenseAgrParam
                    {
                        LicVersion = 1,
                        LicStatus = 0,
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
                LicenseBigR = new ObservableListSource<LicenseBigR>
                {
                    new LicenseBigR
                    {
                        LicVersion = 1,
                        Obj = new ObjectRight
                        {
                            Status = 0,
                            CategoryCode = 6,
                        },
                        MusicalDesign = new ObservableListSource<MusicalDesign>()
                    }
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
                if (RadMessageBox.Show("Вийти без збереження?", "Підтвердження", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation) == DialogResult.Yes)
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

            var mus = _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseBigR.SingleOrDefault()?.MusicalDesign;
            mus?.Add(design);
            AddCompositionForm addCompositionForm = new AddCompositionForm(mus?.LastOrDefault());
            if (addCompositionForm.ShowDialog() != DialogResult.OK)
                mus?.Remove(design);
            else
                RefreshGridDataSource();
        }

        private void RefreshGridDataSource()
        {
            var source = _customer?.Client?.LicenseAgreement?.LastOrDefault()?.LicenseBigR
                .SingleOrDefault()?.MusicalDesign.Where(rec => rec.ActNumb == (int)ddlActType.SelectedValue)?.ToList();
            gvViewActList.DataSource = source;
        }

        private void gvViewActList_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var delItem = e.Row.DataBoundItem as MusicalDesign;
            _customer.Client.LicenseAgreement.LastOrDefault()?.LicenseBigR.SingleOrDefault()?.MusicalDesign.Remove(delItem);
            RefreshGridDataSource();
        }
    }
}
