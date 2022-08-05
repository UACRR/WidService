using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IPSComponentLibrary.Extensions;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerControls.Calculation;
using IpsViewComponentLibrary.ConsumerControls.SmallRight;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class DistributionForm : RadForm
    {
        private IAgreementData _licenseAgr;
        private List<GridPeriods> _source;
        private MoneyReceived _pay;

        public DistributionForm(MoneyReceived undistrinbMoney, IAgreementData licenseAgr, PaidPeriod period)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            ctrlSaveCancelButtons.ButtonSaveDialogResult = DialogResult.OK;
            ctrlSaveCancelButtons.SaveClck += btnSave_Click;

            _licenseAgr = licenseAgr;
            _pay = undistrinbMoney;

            bindingSource.DataSource = undistrinbMoney;
            bsAgreement.DataSource = licenseAgr;

            var agrLicenseType = IpsGlobal.AnketaDictionaties.agrLicenseType.First(rec => rec.CodeI == licenseAgr.Lic.LicCode);

            txtPayDistribution.Text = $"{undistrinbMoney.Amount - undistrinbMoney.DestribAmount:N2}";

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
                    SchemaType = agrLicenseType.SchemaId,
                    MaxSum = GetMaxSumForPeriod(rec)
                }).ToList();

            gvDistributionPayment.DataSource = _source;
            
            //_calculator = new Calcularor(undistrinbMoney.Amount - undistrinbMoney.DestribAmount - (undistrinbMoney.DestribPrepay ?? 0), _source);
            Calcularor.SetData(undistrinbMoney.Amount - undistrinbMoney.DestribAmount, _source);
            Calcularor.Calculate();
        }

        /// <summary>
        /// Отримати максимальну суму для періоду 
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        private decimal? GetMaxSumForPeriod(PaidPeriod period)
        {
            if (period.RegisterRatedList.Count == 0)
            {
                MessageShow.ShowError("Для періода відсутній розрахунковий лист!");
                return default(decimal);
            }

            // сума Р/Л не проставлена
            if (period.RegisterRatedList.Any(item => item.Royalty == null))
                return null;

            // 0 якщо сума від'ємна
            return Math.Max(decimal.Zero, period.RegisterRatedList.Sum(rec => (rec.Royalty ?? 0) - (rec.PaidAmount ?? 0)));
        }

        private void btnSave_Click(object sender, EventArgs e)
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

            if (period.DistAmount < 0)
                period.DistAmount = 0;

            // Якщо встановлено Royalty та введено суму більшу за максимально допустиму для Р/Л
            if (period.MaxSum != null && period.MaxSum < period.DistAmount)
            {
                MessageBox.Show($"Сума періоду повина бути не більша за {period.MaxSum}", "ПОМИЛКА ВИЗНАЧЕННЯ СУМИ ПЕРІОДУ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                period.DistAmount = period.MaxSum ?? 0;
            }

            // SchemaType для договірів з театрами(великі права) null 
            if (new int?[] {null, 2, 3}.Contains(period.SchemaType))
            {
                bool isValid = period.DistAmount + period.AmountBound <= period.Amount;
                if (!isValid)
                {
                    MessageBox.Show($"Сума значень «сума прив'язки» та «привязано» перевищують вимогу періода {period.Amount:N2}", "ПОМИЛКА ВИЗНАЧЕННЯ СУМИ ПЕРІОДУ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    period.DistAmount = period.Amount - period.AmountBound;
                }
            }

            period.AutoSet = false;
            Calcularor.Calculate();

            gvDistributionPayment.MasterTemplate.Refresh();
        }
    }

    static class Calcularor
    {
        private static readonly List<GridPeriods> List = new List<GridPeriods>();
        private static decimal Rest;

        public static void SetData(decimal rest, IEnumerable<GridPeriods> periods)
        {
            Rest = rest;
            List.Clear();
            List.AddRange(periods);

            Calculate();
        }

        public static void Calculate()
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
