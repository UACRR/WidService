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
        private Calcularor _calculator;
        private LicenseAgreement _licenseAgr;
        private List<GridPeriods> _source;
        private MoneyReceived _pay;
        public DistributionForm()
        {
            InitializeComponent();
        }


        public DistributionForm(MoneyReceived undistrinbMoney, LicenseAgreement licenseAgr, PaidPeriod period)
        {
            InitializeComponent();

            _licenseAgr = licenseAgr;
            _pay = undistrinbMoney;

            bindingSource.DataSource = undistrinbMoney;
            bindingSourceAgreement.DataSource = licenseAgr.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == licenseAgr.LicVersion );
            _source = licenseAgr.PaidPeriod.Where(rec => rec.Status < 7 && (period == null || period.PeriodId == rec.PeriodId)).OrderBy(rec => rec.BeginDate)
                .Select(rec => new GridPeriods
                {
                    PeriodId = rec.PeriodId,
                    Amount = rec.Amount,
                    PeriodName = rec.PeriodName,
                    AmountBound = rec.Undistribamount + rec.Distribamount,
                    Arrears = Math.Max(0, rec.Amount - (rec.Undistribamount + rec.Distribamount)),
                    DistAmount = 0,
                    Status = rec.Status,
                    AutoSet = period != null && period.PeriodId == rec.PeriodId ? true : false
                }).ToList(); //periodsList as List<GridPeriods>;
            gvDistributionPayment.DataSource = _source;
            _calculator = new Calcularor(undistrinbMoney.Amount - undistrinbMoney.DestribAmount - (undistrinbMoney.DestribPrepay ?? 0), _source);

            SetDataSources();
        }

        //встановити джерело для грідів
        private void SetDataSources()
        {
            _calculator.Calculate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveDistrib_Click(object sender, EventArgs e)
        {
            var paidDic = _licenseAgr.PaidPeriod.ToDictionary(rec => rec.PeriodId);
            foreach( var item in _source.Where(rec => rec.DistAmount > 0) )
            {
                PaidPeriod period = paidDic[item.PeriodId];
                var link = period.MoneyPeriodLink.SingleOrDefault(rec => rec.PaidId == _pay.PaidId);
                if( link == null )
                {
                    link = new MoneyPeriodLink {
                        PeriodId = item.PeriodId,
                        PaidId = _pay.PaidId,
                        Paid = _pay,
                        Amount = 0,
                        LicId = _licenseAgr.LicId,
                        Status = 1,
                        Lic = _licenseAgr,
                        Period = period
                    };

                    period.MoneyPeriodLink.Add(link);
                }

                link.Amount += item.DistAmount;
                period.Undistribamount += item.DistAmount;
                link.Paid.DestribAmount += item.DistAmount;
            }
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

            period.AutoSet = false;
            _calculator.Calculate();

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
            decimal manualRest = List.Where(rec => rec.AutoSet == false).Sum(rec => rec.DistAmount);
            decimal freeRest = Rest - manualRest;

            if (freeRest == 0)
                return;

            foreach (var item in List.Where(rec => rec.AutoSet == true))
            {
                decimal curRest = Math.Min(freeRest, item.Arrears);
                item.DistAmount = curRest;
                freeRest -= curRest;

                if (freeRest == 0) break;
            }
        }
    }
}
