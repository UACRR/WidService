using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerControls.SmallRight;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class DistributionForm : RadForm
    {
        private Calcularor _calculator;
        private IAgreementData _licenseAgr;
        private List<GridPeriods> _source;
        private MoneyReceived _pay;

        /// <summary>
        /// Отримати максимальну суму для періоду 
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        private decimal? GetMaxSumForPeriod(PaidPeriod period)
        {
            // сума Р/Л не проставлена
            if (period.RegisterRatedList.Any(item => item.Royalty == null))
                return null;
            // 0 якщо сума від'ємна
            return Math.Max( decimal.Zero ,  period.RegisterRatedList.Sum(rec => (rec.Royalty ?? 0 ) - (rec.PaidAmount ?? 0)) );
        }

        public DistributionForm(MoneyReceived undistrinbMoney, IAgreementData licenseAgr, PaidPeriod period)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _licenseAgr = licenseAgr;
            _pay = undistrinbMoney;

            bindingSource.DataSource = undistrinbMoney;
            bindingSourceAgreement.DataSource = licenseAgr;

            SetTxtPayDistribution(undistrinbMoney);
            _source = licenseAgr.Lic.PaidPeriod
                .Where(rec => (rec.Status >= 2 && rec.Status < 7) && (period == null || period.PeriodId == rec.PeriodId))
                .OrderBy(rec => rec.BeginDate)
                .Select(rec => new GridPeriods
                {
                    PeriodId = rec.PeriodId,
                    Amount = rec.Amount,
                    PeriodName = rec.PeriodName,
                    AmountBound = rec.Undistribamount + rec.Distribamount,
                    Arrears = Math.Max(0, rec.Amount - (rec.Undistribamount + rec.Distribamount)),
                    DistAmount = 0,
                    Status = rec.Status,
                    AutoSet = period != null && period.PeriodId == rec.PeriodId,
                    MaxSum = GetMaxSumForPeriod(rec)
                }).ToList(); //periodsList as List<GridPeriods>;
            gvDistributionPayment.DataSource = _source;
            _calculator = new Calcularor(undistrinbMoney.Amount - undistrinbMoney.DestribAmount - (undistrinbMoney.DestribPrepay ?? 0), _source);

            SetDataSources();
        }

        private void SetTxtPayDistribution(MoneyReceived pay)
        {
            txtPayDistribution.Text =  string.Format("{0:# ### ### ##0.00}", pay.Amount - pay.DestribAmount);
        }

        //встановити джерело для грідів
        private void SetDataSources()
        {
            _calculator.Calculate();
        }

        private void BtnSaveDistrib_Click(object sender, EventArgs e)
        {
            var paidDic = _licenseAgr.Lic.PaidPeriod.ToDictionary(rec => rec.PeriodId);
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
                        LicId = _licenseAgr.Lic.LicId,
                        Status = 1,
                        Lic = _licenseAgr.Lic,
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

        private void GvDistributionPayment_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.FieldName != "DistAmount")
                return;

            var period = e.Row.DataBoundItem as GridPeriods;

            // Якщо встановлено Royalty та введено суму більшу за максимально допустиму для Р/Л
            if( period.MaxSum != null && period.MaxSum < period.DistAmount )
            {
                MessageBox.Show($"Сума періоду повина бути не більша за {period.MaxSum}", "ПОМИЛКА ВИЗНАЧЕННЯ СУМИ ПЕРІОДУ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                period.DistAmount = period.MaxSum ?? 0;
            }

            period.AutoSet = false;
            _calculator.Calculate();

            gvDistributionPayment.MasterTemplate.Refresh();
        }
    }



    class Calcularor
    {
        private List<GridPeriods> List = new List<GridPeriods>();
        private readonly decimal Rest = 0;

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
                decimal curRest = Math.Min( Math.Min(freeRest, item.Arrears), item.MaxSum ?? freeRest);
                item.DistAmount = curRest;
                freeRest -= curRest;

                if (freeRest == 0) break;
            }
        }
    }
}
