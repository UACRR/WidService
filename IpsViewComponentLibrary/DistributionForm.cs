using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    //    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class DistributionForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _cust;
        private object _distribMoneyDataSource;
        private Calcularor _calculator;
        public DistributionForm()
        {
            InitializeComponent();
        }


        public DistributionForm(MoneyReceived undistrinbMoney, LicenseAgreement licenseAgr)
        {
            InitializeComponent();

            bindingSource.DataSource = undistrinbMoney;
            bindingSourceAgreement.DataSource = licenseAgr.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == licenseAgr.LicVersion );
            var source = licenseAgr.PaidPeriod.Where(rec => rec.Status < 2).OrderBy( rec => rec.BeginDate ).Select(rec => new GridPeriods
            {
                PeriodId = rec.PeriodId,
                Amount = rec.Amount,
                PeriodName = rec.PeriodName,
                AmountBound = rec.Undistribamount + rec.Distribamount,
                Arrears = rec.Amount - rec.Undistribamount + rec.Distribamount,
                DistAmount = 0,
                Status = rec.Status
            }).ToList(); //periodsList as List<GridPeriods>;

            gvDistributionPayment.DataSource = source;
            _calculator = new Calcularor(undistrinbMoney.Amount - undistrinbMoney.DestribAmount - (undistrinbMoney.DestribPrepay ?? 0), source);

            SetDataSources();
        }

        //встановити джерело для грідів
        private void SetDataSources()
        {
            _calculator.Calculate();
        }

        private void btnSaveDistrib_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void gvDistributionPayment_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.FieldName != "DistAmount")
                return;

            var period = e.Row.DataBoundItem as GridPeriods;

            period.ManualSet = true;
            _calculator.Calculate();

            if (Convert.ToDecimal(e.Value) != 0)
                period.ManualSet = true;
            else
                period.ManualSet = false;

            gvDistributionPayment.MasterTemplate.Refresh();
        }
    }



    class Calcularor
    {
        private List<GridPeriods> List = new List<GridPeriods>();
        private decimal Rest = 0;

        public Calcularor(decimal rest, List<GridPeriods> periods)
        {
            Rest = rest;
            List.Clear();
            List.AddRange(periods);

            Calculate();
        }

        public void Calculate()
        {
            decimal manualRest = List.Where(rec => rec.ManualSet == true).Sum(rec => rec.DistAmount);
            decimal freeRest = Rest - manualRest;

            if (freeRest == 0)
                return;

            foreach (var item in List.Where(rec => rec.ManualSet == false))
            {
                decimal curRest = Math.Min(freeRest, item.Arrears);
                item.DistAmount = curRest;
                freeRest -= curRest;

                if (freeRest == 0) break;
            }
        }
    }
}
