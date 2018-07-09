using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private Customer _customer;
        private LicenseAgreement _license;
        private LicenseAgrParam _licenseAgr;
        private ObservableListSource<ClnBusinessPlace> _places = new ObservableListSource<ClnBusinessPlace>();
        private ObservableListSource<ClnBusinessPlace> _tempPlaces;
        private ConsumerAgreementInitType _agreementInitType = ConsumerAgreementInitType.None;

        public MiddleControlAgreementProlPlacesType()
        {
            InitializeComponent();
        }

        public TypeRights Rights { get; set; }
        public AnketaDictionaties Dictionaties { get; set; }

        public void InitializeObjects(Customer cust, ObservableListSource<ClnBusinessPlace> places, LicenseAgreement license, LicenseAgrParam licenseAgr, ConsumerAgreementInitType agreementInitType)
        {
            _agreementInitType = agreementInitType;
            _customer = cust;
            _tempPlaces = places;
            _license = license;
            _licenseAgr = licenseAgr;

            licenseAgreementBindingSource.DataSource = license;


            //TODO: джерело даних з розрахованою сумою
            SetChoosePlaces();

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

        public bool CanChangeLicense
        {
            get => ddlLicType.ReadOnly;
            set => ddlLicType.ReadOnly = !value;
        }

        public bool LicenseEnabled
        {
            get => ddlLicType.Enabled;
            set => ddlLicType.Enabled = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSourceAgreement
        {
            get => bindingSourceAgr.DataSource;
            set => bindingSourceAgr.DataSource = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSourceAnketaCompany
        {
            get => bindingSourceAnketaCompany.DataSource;
            set => bindingSourceAnketaCompany.DataSource = value;
        }

        public LicenseAgrParam LicenseAgrParam
        {
            get => null;
            set
            {
                var licenseParam = value;
                ctrlAgrSecond.DataSourceBinding = licenseParam;
                ctrlAgrSecond.AutoprolongationDataSource = licenseParam;
                ctrlAgrSecond.MinPayment = "MinAmount";
                ctrlAgrSecond.PercentPayment = "RateAmount";

                ctrlAgrSecond.PeriodPaymentDataSource = Dictionaties?.period;
                ctrlAgrSecond.PeriodPaymentValueMember = "codeI";
                ctrlAgrSecond.PeriodPaymentDisplayMember = "name";
                ctrlAgrSecond.PeriodPaymentDataMember = "PeriodCode";
                ctrlAgrSecond.PeriodPaymentSelectedValue = licenseParam?.PeriodCode;

                if (licenseParam?.AddRate == null && licenseParam?.IndxInfl != null)
                    ctrlAgrSecond.SelectedItem = 1;
                else if (licenseParam?.AddRate != null && licenseParam.IndxInfl == null)
                    ctrlAgrSecond.SelectedItem = 0;
                else
                    ctrlAgrSecond.AutoprolongationPercent = null;
            }

        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            OnPrintClick?.Invoke();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveChangesClick?.Invoke();
        }

        private void gvPlaces_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var id = (int)e.Row.Cells["PlaceId"].Value;

            if (_licenseAgr.License == null)
             _licenseAgr.License = new ObservableListSource<LicenseForPlaces>();   
            
            
            if (e?.Value != null && (bool)e.Value)
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
                //_places.Add(_tempPlaces.SingleOrDefault(rec => rec.PlaceId == id));
            }
            else if (e?.Value != null && !(bool)e.Value)
            {
                _licenseAgr.License.Remove(_licenseAgr.License.SingleOrDefault(rec => rec.PlaceId == id));
                //_places.Remove(_tempPlaces.SingleOrDefault(rec => rec.PlaceId == id));
            }
        }

        //обрати чекбокс майданчиків що в ліцензії
        private void SetChoosePlaces()
        {
            gvPlaces.DataSource = _tempPlaces;
            if (_agreementInitType == ConsumerAgreementInitType.EditAgreement ||
                _agreementInitType == ConsumerAgreementInitType.Prolongation)
            {
                gvPlaces.CellValueChanged -= gvPlaces_CellValueChanged;
                foreach (var item in _licenseAgr.License)
                {
                    gvPlaces.Rows.SingleOrDefault(row => Convert.ToInt32(row.Cells["PlaceId"].Value) == item.PlaceId).Cells["CheckIn"].Value = true;
                }
                gvPlaces.CellValueChanged += gvPlaces_CellValueChanged;
            }
        }
    }
}
