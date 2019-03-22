using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;
using LicenseForPlaces = ipsFormsDesign.Model.License;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class AgreementWithPlacesControl : UserControl
    {
        private LicenseAgreement _license;
        private LicenseAgrParam _licenseAgr;
        private ObservableListSource<ClnBusinessPlace> _tempPlaces;
        private List<GridViewRowInfo> _existLicenses;
        private readonly AnketaDictionaties _anketaDictionaties;
        private bool _selectFirstItemNeed;
        private bool _firstSelectChanging = true;
        private static bool PlaceChooserPredicate(GridViewRowInfo row, LicenseForPlaces license) => row.DataBoundItem as ClnBusinessPlace == license.Place
                                                                         || (row.DataBoundItem as ClnBusinessPlace)?.PlaceId == license.PlaceId;

        public AgreementWithPlacesControl()
        {
            InitializeComponent();
            _existLicenses = new List<GridViewRowInfo>();
            if (IpsGlobal.AnketaDictionaties != null)
                _anketaDictionaties = IpsGlobal.AnketaDictionaties;
        }

        public TypeRights Rights { get; set; }

        public void InitializeObjects(ObservableListSource<ClnBusinessPlace> places, LicenseAgreement license, LicenseAgrParam licenseAgr, ConsumerAgreementInitType agreementInitType)
        {
            _selectFirstItemNeed = agreementInitType == ConsumerAgreementInitType.AddNewAgreement;
            _tempPlaces = places;
            _licenseAgr = licenseAgr;
            _license = license;

            _firstSelectChanging = true;
            licenseAgreementBindingSource.DataSource = _license;
            bindingSourceAgr.DataSource = _licenseAgr;

            ctrlAgrSecond.DataSourceBinding = _licenseAgr;
            ctrlAgrSecond.AutoprolongationDataSource = _licenseAgr;
            ctrlAgrSecond.MinPayment = "MinAmount";
            ctrlAgrSecond.PercentPayment = "RateAmount";

            ctrlAgrSecond.PeriodPaymentDataSource = _anketaDictionaties.period;
            ctrlAgrSecond.PeriodPaymentValueMember = "codeI";
            ctrlAgrSecond.PeriodPaymentDisplayMember = "name";
            ctrlAgrSecond.PeriodPaymentDataMember = "PeriodCode";
            ctrlAgrSecond.PeriodPaymentSelectedValue = _licenseAgr?.PeriodCode;

            if (_licenseAgr?.AddRate == null && _licenseAgr?.IndxInfl != null)
                ctrlAgrSecond.SelectedItem = 1;
            else if (_licenseAgr?.AddRate != null && _licenseAgr.IndxInfl == null)
                ctrlAgrSecond.SelectedItem = 0;
            else
                ctrlAgrSecond.AutoprolongationPercent = null;

            CheckPlaces();

            ctrlAgrMain.DataSource = _licenseAgr;
            ctrlAgrMain.DateTimeType = agreementInitType;
            bindingSourceDictionary.DataSource = _anketaDictionaties.agrLicenseType.Where(rec =>
            {
                switch (Rights)
                {
                    case TypeRights.SmallRights:
                        return rec.UsesKind != 1;
                    case TypeRights.BigRights:
                        return rec.UsesKind == 1;
                }
                return true;
            });
        }

        public bool Validator()
        {
            bool isValid = true;
            // TODO: перевірка валідації
            return isValid;
        }

        private void CheckPlaces()
        {
            if (_tempPlaces != null && _tempPlaces.Any())
            {
                SetChoosePlaces();
                gvPlaces.Enabled = true;
            }
            else
                gvPlaces.Enabled = false;
        }

        private void AgreementWithPlacesControl_Paint(object sender, PaintEventArgs e)
        {
            CheckPlaces();
        }

        /// <summary>
        /// Закріпляти, навіть якщо прострочений
        /// </summary>
        public bool IsAttached
        {
            get => checkAttach.Checked;
            set => checkAttach.Checked = value;
        }

        public bool LicenseEnabled
        {
            get => ddlLicType.Enabled;
            set
            {
                ddlLicType.Enabled = value;
                txtSeries.Enabled = value;
            }
        }

        //початковий вибір чекбокс майданчиків що в ліцензії
        private void SetChoosePlaces()
        {
            gvPlaces.DataSource = _tempPlaces;

            foreach (var item in _licenseAgr.License)
            {
                var gvPlacesRow = gvPlaces.Rows.SingleOrDefault(row => PlaceChooserPredicate(row, item));
                if (gvPlacesRow != null)
                {
                    gvPlacesRow.Cells["CheckIn"].Value = true;
                    if (!_existLicenses.Contains(gvPlacesRow))
                        _existLicenses.Add(gvPlacesRow);
                }
            }
        }

        /// <summary>
        /// Оновити обрані майданчики в ліцензійному договорі
        /// </summary>
        public void UpdateLicenses()
        {
            if (gvPlaces.RowCount == 0)
                return;

            if (_licenseAgr.License == null)
                _licenseAgr.License = new ObservableListSource<LicenseForPlaces>();

            foreach (var placesRow in gvPlaces.Rows)
            {
                if (!(placesRow.Cells["CheckIn"].Value is bool isChecked)) continue;
                var item = placesRow.DataBoundItem as ClnBusinessPlace;

                if (isChecked)
                {
                    if (_existLicenses.Contains(placesRow)) continue;
                    var newLicense = new LicenseForPlaces
                    {
                        PlaceId = item.PlaceId,
                        LicId = _licenseAgr.LicId,
                        LicVersion = _licenseAgr.LicVersion,
                        LNum = "0" + (DateTime.Today.Year - 2000) + @"/" + (DateTime.Today.DayOfYear),
                        LDate = DateTime.Today,
                        Place = item,
                    };
                    _licenseAgr.License.Add(newLicense);
                    item.License.Add(newLicense);
                }
                else
                {
                    var license = _licenseAgr.License.SingleOrDefault(rec => rec.Place == item || (rec.PlaceId == item.PlaceId && item.PlaceId != 0));
                    _licenseAgr.License.Remove(license);
                    item.License.Remove(license);
                }
            }

            foreach (var lic in _licenseAgr.License)
                lic.Place = null;
            foreach (var place in _tempPlaces)
                foreach (var license in place.License)
                    license.Place = null;
        }

        private void AgreementWithPlacesControl_Load(object sender, EventArgs e)
        {
            if (!_selectFirstItemNeed)
                return;
            ddlLicType.SelectedIndex = 0;
            ctrlAgrSecond.SelectDefaultItem();
        }

        private void ddlLicType_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            if(_firstSelectChanging || e.Position < 0 )
            {
                _firstSelectChanging = false;
                return;
            }
            var source = ddlLicType.DataSource as BindingSource;
            var list = source.List;
            // Отримати поточний тип ліцензії
            var agrLicType = list[e.Position] as AgrLicenseType;
            // Якщо встановлено % авторської винагороди то просавляємо в контракт
            if (agrLicType != null && agrLicType.CodeI != _license.LicCode )
            {
                _licenseAgr.RateAmount = agrLicType.AuthRate;
                ctrlAgrSecond.RefreshDataSourceBinding();
            }
        }

    }
}
