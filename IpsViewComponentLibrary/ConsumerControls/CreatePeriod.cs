using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class CreatePeriod : Form
    {
        private LicenseAgreement _lic;
        private PeriodStatus dicStatus;
        public CreatePeriod(LicenseAgreement lic)
        {
            _lic = lic;
            dicStatus = IpsGlobal.AnketaDictionaties.periodStatus.SingleOrDefault(rec => rec.CodeI == 1);
            InitializeComponent();
            // Створити масив періодів
            initControls();

        }

        private void initControls()
        {
            var lastPeriod = _lic.PaidPeriod.Count() > 0 ? _lic.PaidPeriod.OrderBy(rec => rec.BeginDate).LastOrDefault() : null;
            var beginDate = lastPeriod?.EndDate.AddDays(1) ?? DateTime.Today;
            
            computeFirstDate(beginDate);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastPeriod"></param>
        /// <returns></returns>
        private DateTime getBeginDate(DateTime lastPeriod)
        {
            DateTime workDate = lastPeriod;
            workDate = workDate.AddDays(-workDate.Day + 1);
            return workDate;
        }

        private void computeFirstDate(DateTime lastPeriod)
        {

            DateTime beginDateNewPeriod = getBeginDate(lastPeriod);
            radDateTimePicker1.Value = beginDateNewPeriod;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginDateNewPeriod"></param>
        /// <param name="cntInList"></param>
        private void FormDorpDown(DateTime beginDateNewPeriod, int cntInList = 4)
        {
            // Щомісячно
            int cntMonth = 1;
            string[] quartals = { "I", "II", "III", "IV" };
            string[] halfYear = { "I", "II" };

            Func<DateTime, string>[] namePeriods = {
                (d)=>{ return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(string.Format( "{0:MMMM} {0:yyyy} року", d )); }, // Місяць 
                (d)=>{ return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(string.Format( "{0} квартал {1:yyyy} року", d.Month / 3 + 1, d )); }, // Квартал
                (d)=>{ return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(string.Format( "{0} півріччя {1:yyyy} року", d.Month/6+1, d )); }, // Півріччя
                (d)=>{ return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(string.Format( "{0:yyyy} рок", d )); }, // Рік
            };
            Func<DateTime, string> namePariod = namePeriods[0];
            int PeriodCode = 0;
            decimal? MinAmount = 0;

            if ( _lic.LicClass == 1 )
            {
                var agree = _lic.Agr.AgreementAddBr.Single(rec => rec.Version == _lic.Agr.Version);
                PeriodCode = agree.PeriodCode ?? 1;
                MinAmount = 0;
            }
            else
            {
                var agree = _lic.LicenseAgrParam.Single(rec => rec.LicVersion == _lic.LicVersion);
                PeriodCode = agree.PeriodCode ?? 1;
                MinAmount = agree.MinAmount;

            }

            switch (PeriodCode)
            {
                // Поквартально
                case 2:
                    cntMonth = 3;
                    namePariod = namePeriods[1];
                    break;
                // Раз в півроку
                case 3:
                    cntMonth = 6;
                    namePariod = namePeriods[2];
                    break;
                // раз в рік
                case 4:
                    cntMonth = 12;
                    namePariod = namePeriods[3];
                    break;
                default:
                    break;
            }

            radDropDownList1.Items.Clear();
            for (int i = 0; i < cntInList; i++)
            {
                var newPeriod = new PaidPeriod
                {
                    Lic = _lic,
                    LicId = _lic.LicId,
                    BeginDate = beginDateNewPeriod,
                    EndDate = beginDateNewPeriod.AddMonths(cntMonth).AddDays(-1),
                    PeriodName = namePariod(beginDateNewPeriod),
                    PeriodType = (int)PeriodCode,
                    Amount = MinAmount ?? 0,
                    Distribamount = 0,
                    Undistribamount = 0,
                    Status = 1,
                    CustId = (int)_lic.CustId,
                    StatusNavigation = dicStatus
                };

                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Text = newPeriod.PeriodName;
                dataItem.Tag = newPeriod;
                radDropDownList1.Items.Add(dataItem);
                beginDateNewPeriod = beginDateNewPeriod.AddMonths(cntMonth);
            }

            radDropDownList1.Items[0].Selected = true;
        }

        bool entry = false;
        private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (entry) return;
            entry = true;

            var begDate = getBeginDate(radDateTimePicker1.Value);
            var firstPeriod = radDropDownList1.Items.Count > 0 ? radDropDownList1.Items[0].Tag as PaidPeriod : null;
            if (begDate != firstPeriod?.BeginDate)
                FormDorpDown(begDate);
            entry = false;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            var check = _lic.PaidPeriod.FirstOrDefault(rec => rec.BeginDate == radDateTimePicker1.Value);
            if (check == null)
            {
                var addPeriod = (PaidPeriod)radDropDownList1.SelectedItem.Tag;
                if (_lic.PaidPeriod.Count == 0) // firstPeriod
                    addPeriod.FagFirst = true;
                _lic.PaidPeriod.Add(addPeriod);
            }

            DialogResult = DialogResult.OK;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
