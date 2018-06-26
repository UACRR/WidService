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

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlAgreementProlPlacesType : UserControl
    {
        public delegate void SaveChange();
        public event SaveChange OnSaveChangesClick;

        public delegate void Print();
        public event Print OnPrintClick;
        private Customer _customer;
        private ObservableListSource<ClnBusinessPlace> _places = new ObservableListSource<ClnBusinessPlace>();
        private ObservableListSource<ClnBusinessPlace> _tempPlaces;

        public MiddleControlAgreementProlPlacesType()
        {
            InitializeComponent();
        }

        public void InitializeObjects(Customer cust, ObservableListSource<ClnBusinessPlace> places)
        {
            _customer = cust;
            _tempPlaces = places;
        }


        public string LicenseName
        {
            get => lblTitleLicAgr.Text;
            set => lblTitleLicAgr.Text = value;
        }

        //TODO: джерело даних з розрахованою сумою
        public object DataSourceGrid
        {
            get => gvPlaces.DataSource;
            set => gvPlaces.DataSource = value;
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
                ctrlAgrSecond.IsAutoprolongation = licenseParam?.IsAutoprolog ?? false;
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

        public AnketaDictionaties Dictionaties { get; set; }

        private void btnAddPlace_Click(object sender, EventArgs e)
        {
            //TODO: додавання майданчика
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            OnPrintClick?.Invoke();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _customer.Client.ClnBusinessPlace = _places;

            OnSaveChangesClick?.Invoke();
        }

        private void gvPlaces_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //TODO: checkbox event обрані майданчики додати до ліцензії

            var id = (int)e.Row.Cells["PlaceId"].Value;
            if (e?.Value != null && (bool)e.Value)
            {
                _places.Add(_tempPlaces.SingleOrDefault(rec => rec.PlaceId == id));
            }
            else if (e?.Value != null && !(bool)e.Value)
            {
                _places.Remove(_tempPlaces.SingleOrDefault(rec => rec.PlaceId == id));
            }

        }
    }
}
