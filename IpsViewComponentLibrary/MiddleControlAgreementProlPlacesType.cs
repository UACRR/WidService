using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using LicenseForPlaces = ipsFormsDesign.Model.License;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlAgreementProlPlacesType : UserControl
    {
        public delegate void SaveChange();
        public event SaveChange OnSaveChangesClick;

        public delegate void Print();
        public event Print OnPrintClick;

        decimal _minAmount = default(decimal);
        private LicenseAgrParam _licenseAgr;
        private ObservableListSource<ClnBusinessPlace> _tempPlaces;
        private ConsumerAgreementInitType _agreementInitType = ConsumerAgreementInitType.None;

        public MiddleControlAgreementProlPlacesType()
        {
            InitializeComponent();
        }

        public TypeRights Rights { get; set; }
        public AnketaDictionaties Dictionaties { get; set; }

        public void InitializeObjects(ObservableListSource<ClnBusinessPlace> places, LicenseAgreement license, LicenseAgrParam licenseAgr, ConsumerAgreementInitType agreementInitType)
        {
            _agreementInitType = agreementInitType;
            _tempPlaces = places;
            _licenseAgr = licenseAgr;

            licenseAgreementBindingSource.DataSource = license;
            bindingSourceAgr.DataSource = _licenseAgr;
            
            ctrlAgrSecond.DataSourceBinding = _licenseAgr;
            ctrlAgrSecond.AutoprolongationDataSource = _licenseAgr;
            ctrlAgrSecond.MinPayment = "MinAmount";
            ctrlAgrSecond.PercentPayment = "RateAmount";

            ctrlAgrSecond.PeriodPaymentDataSource = Dictionaties?.period;
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
            

            //TODO: джерело даних з розрахованою сумою
            if (places != null && places.Any())
                SetChoosePlaces();
            else
                gvPlaces.Enabled = false;

            ctrlAgrMain.DataSource = _licenseAgr;
            ctrlAgrMain.DateTimeType = agreementInitType;
            bindingSourceDictionary.DataSource = Dictionaties?.agrLicenseType.Where(rec =>
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
            set => ddlLicType.Enabled = value;
        }

        /// <summary>
        /// Найменування customer
        /// </summary>
        public string ClientName
        {
            get => lblTitleClientName.Text;
            set => lblTitleClientName.Text = value;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            OnPrintClick?.Invoke();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveChangesClick?.Invoke();
        }

        //при зміні чекбокс
        private void gvPlaces_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var id = (int)e.Row.Cells["PlaceId"].Value;

            if (_licenseAgr.License == null)
             _licenseAgr.License = new ObservableListSource<LicenseForPlaces>();   
            
            
            if (e.Value != null && (bool)e.Value)
            {
                _licenseAgr.License.Add(new LicenseForPlaces
                {
                    //LId = <pk>
                    PlaceId = _tempPlaces.SingleOrDefault(rec => rec.PlaceId == id)?.PlaceId,
                    LicId = _licenseAgr.LicId,
                    LicVersion = _licenseAgr.LicVersion,
                    LNum = "0" + (DateTime.Today.Year - 2000) + @"/" + (DateTime.Today.DayOfYear),
                    LDate = DateTime.Today,
                    Place = _tempPlaces.SingleOrDefault(rec => rec.PlaceId == id),
                    Status = _licenseAgr.LicStatus
                });
                CalculateMinAmount(CalculationMinAmountType.AddCalcValue, e.Row.DataBoundItem as IntermediateDataSourcePlaces);
            }
            else if (e.Value != null && !(bool)e.Value)
            {
                CalculateMinAmount(CalculationMinAmountType.DeleteCalcValue, e.Row.DataBoundItem as IntermediateDataSourcePlaces);
                _licenseAgr.License.Remove(_licenseAgr.License.SingleOrDefault(rec => rec.PlaceId == id));
            }
        }

        //початковий вибір чекбокс майданчиків що в ліцензії
        private void SetChoosePlaces()
        {
            ObservableListSource<IntermediateDataSourcePlaces> dataSource = new ObservableListSource<IntermediateDataSourcePlaces>();
            foreach (var place in _tempPlaces)
            {
                decimal amount = default(decimal);

                foreach (var holl in place.ClnPlaceHoll)
                {
                    decimal.TryParse(holl.ValuePlace, out decimal a);
                    amount += a;
                }

                dataSource.Add(new IntermediateDataSourcePlaces
                {
                    PlaceId = place.PlaceId,
                    PlaceName = place.PlaceName,
                    PlaceAddress = place.PlaceAddress,
                    Amount = amount
                });
            }
            gvPlaces.DataSource = dataSource;

            if (_agreementInitType == ConsumerAgreementInitType.EditAgreement ||
                _agreementInitType == ConsumerAgreementInitType.Prolongation ||
                _agreementInitType == ConsumerAgreementInitType.ChangeAgreement)
            {
                gvPlaces.CellValueChanged -= gvPlaces_CellValueChanged;
                foreach (var item in _licenseAgr.License)
                {
                    // Оптимизация доступ к строке грида в переменную
                    // Патлякевич 
                    var gvPlacesRow = gvPlaces.Rows.SingleOrDefault(row => Convert.ToInt32(row.Cells["PlaceId"]?.Value) == item.PlaceId);
                    if (gvPlacesRow == null)
                        continue;
                    gvPlacesRow.Cells["CheckIn"].Value = true;
                    var place = gvPlacesRow?.DataBoundItem as IntermediateDataSourcePlaces;
                    CalculateMinAmount(CalculationMinAmountType.AddCalcValue, place);
                }
                gvPlaces.CellValueChanged += gvPlaces_CellValueChanged;
            }
        }

        private void CalculateMinAmount(CalculationMinAmountType calcType, IntermediateDataSourcePlaces place)
        {
            switch (calcType)
            {
                case CalculationMinAmountType.AddCalcValue:
                    _minAmount += place.Amount;
                    break;
            
                case CalculationMinAmountType.DeleteCalcValue:
                    _minAmount -= place.Amount;
                    break;
            }
                
            ctrlAgrSecond.MinAmount = _minAmount;
        }
    }

    /// <summary>
    /// Проміжний клас для відображення даних на грід та зручним обрахуванням суми
    /// </summary>
    internal class IntermediateDataSourcePlaces
    {
        public int PlaceId { get; set; }
        public string PlaceAddress { get; set; }
        public string PlaceName { get; set; }
        public decimal Amount { get; set; }
    }
}
