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
    public partial class MiddleControlAgreementAnketaType : UserControl//, IMiddleCtrlAnketaConsumer
    {
        private LicenseAgrParam _licenseAgr;
        private ConsumerAnketeType _consumerAnketeType = ConsumerAnketeType.None;
        private Customer _customer;
        public MiddleControlAgreementAnketaType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Тип права
        /// </summary>
        public TypeRights typeRights { get; set; } = TypeRights.SmallRights;

        /// <summary>
        /// Встановлення даних
        /// </summary>
        /// <param name="cust">Споживач</param>
        /// <param name="dictionaties">Словник</param>
        public void SetDataSources(Customer cust, AnketaDictionaties dictionaties, ConsumerAnketeType anketeType )
        {
            _consumerAnketeType = anketeType;
            _customer = cust;
            AnketaCompany anketa = cust?.Company?.AnketaCompany?.SingleOrDefault(rec => rec?.Version == cust?.AnkVersion);
            var license = cust?.Client?.LicenseAgreement?.FirstOrDefault(rec => rec.LicStatus < 4);
            var licenseParam = license?.LicenseAgrParam?.SingleOrDefault(rec => rec?.LicVersion == license?.LicVersion);
            _licenseAgr = licenseParam;
            if(license != null && anketeType == ConsumerAnketeType.CreateNewAnketa)
                license.LicCode = typeRights == TypeRights.SmallRights ? 1 : typeRights == TypeRights.BigRights ? 10 : throw new ArgumentException();

            ddlLicType.DataSource = dictionaties?.agrLicenseType.Where( rec => 
            {
                switch (typeRights)
                {
                    case TypeRights.SmallRights:
                        return rec.UsesKind != 1;
                    case TypeRights.BigRights:
                        return rec.UsesKind == 1;
                }
                return true;
            });

            ddlLicType.DataBindings.Clear();
            ddlLicType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", license, "LicCode", true));

            ddlLicType.DisplayMember = "name";
            ddlLicType.ValueMember = "codeI";
            ddlLicType.SelectedValue = license?.LicCode;
           
            

            ctrlAgreementMain.DataSource = licenseParam;
            
            ctrlAgreementSecond.DataSourceBinding = licenseParam;
            ctrlAgreementSecond.AutoprolongationDataSource = licenseParam;
            ctrlAgreementSecond.MinPayment = "MinAmount";
            ctrlAgreementSecond.PercentPayment = "RateAmount";

            ctrlAgreementSecond.PeriodPaymentDataSource = dictionaties?.period;
            ctrlAgreementSecond.PeriodPaymentValueMember = "codeI";
            ctrlAgreementSecond.PeriodPaymentDisplayMember = "name";
            ctrlAgreementSecond.PeriodPaymentDataMember = "PeriodCode";
            ctrlAgreementSecond.PeriodPaymentSelectedValue = licenseParam?.PeriodCode;

            if (licenseParam?.AddRate == null && licenseParam?.IndxInfl != null)
                ctrlAgreementSecond.SelectedItem = 1;
            else if (licenseParam?.AddRate != null && licenseParam.IndxInfl == null)
                ctrlAgreementSecond.SelectedItem = 0;
            else
                ctrlAgreementSecond.AutoprolongationPercent = null;
            lblTitle.Text = anketa?.Name;

            //TODO: джерело даних з розрахованою сумою
            gvPlaces.DataSource = SetChoosePlaces();
        }

        //обрати чекбокс майданчиків що в ліцензії
        private ObservableListSource<ClnBusinessPlace> SetChoosePlaces()
        {
            if (_consumerAnketeType == ConsumerAnketeType.CreateNewAnketa)
                return _customer.Client.ClnBusinessPlace;

            ObservableListSource <ClnBusinessPlace> places = new ObservableListSource<ClnBusinessPlace>();
            foreach (var item in _licenseAgr.License)
            {
                places.Add(_customer?.Client?.ClnBusinessPlace?.Where(rec => rec?.PlaceId == item?.PlaceId).SingleOrDefault());
            }

            return places;
        }

        public bool Validator()
        {
            return ctrlAgreementMain.Validator() && ctrlAgreementSecond.Validator();
        }

        /// <summary>
        /// Видимість параметрів договору
        /// </summary>
        public bool AgreementParamVisible
        {
            get => panel.Visible && lblParam.Visible;
            private set
            {
                panel.Visible = typeRights == TypeRights.SmallRights;
                lblParam.Visible = typeRights == TypeRights.SmallRights;
            }
        }

        internal void SetDefaultListItem()
        {
            if (ddlLicType.Items.Count != 0)
            {
                ddlLicType.SelectedIndex = ddlLicType.Items.Last.Index;
                ddlLicType.SelectedIndex = ddlLicType.Items.First.Index;
            }

            ctrlAgreementSecond.SetDefaultState();
        }

        private void gvPlaces_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var item = gvPlaces.CurrentRow.DataBoundItem as ClnBusinessPlace;

            if (_licenseAgr.License == null)
                _licenseAgr.License = new ObservableListSource<LicenseForPlaces>();

            if (e?.Value != null && (bool)e.Value)
            {
                _licenseAgr.License.Add(new LicenseForPlaces
                {
                    PlaceId = item?.PlaceId,
                    LicId = _licenseAgr.LicId,
                    LicVersion = _licenseAgr.LicVersion,
                    LNum = "0" + (DateTime.Today.Year - 2000) + @"/" + (DateTime.Today.DayOfYear),
                    LDate = DateTime.Today,
                    Place = item,
                    Status = _licenseAgr.LicStatus
                });
            }
            else if (e?.Value != null && !(bool)e.Value)
            {
                _licenseAgr.License.Remove(_licenseAgr.License.SingleOrDefault(rec => rec.PlaceId == item?.PlaceId));
            }
        }
    }
}

