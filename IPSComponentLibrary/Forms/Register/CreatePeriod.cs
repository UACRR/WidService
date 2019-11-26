using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using IPSComponentLibrary.Extensions;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IPSComponentLibrary.Forms.Register
{
    public partial class CreatePeriod : Form
    {
        private readonly LicenseAgreement _licenseAgreement;
        private readonly PeriodStatus dicStatus;

        public CreatePeriod(LicenseAgreement licenseAgreement)
        {
            _licenseAgreement = licenseAgreement;
            dicStatus = IpsGlobal.AnketaDictionaties.periodStatus.SingleOrDefault(rec => rec.CodeI == 1);
            InitializeComponent();
            dtStartDate.SetUserCalendarSettingsm();
            MaximumSize = Size;
            MinimumSize = Size;
            InitControls();
        }

        public sealed override Size MinimumSize
        {
            get => base.MinimumSize;
            set => base.MinimumSize = value;
        }

        public sealed override Size MaximumSize
        {
            get => base.MaximumSize;
            set => base.MaximumSize = value;
        }

        private void InitControls()
        {
            var lastPeriod = _licenseAgreement.PaidPeriod.Any() ? _licenseAgreement.PaidPeriod.OrderBy(rec => rec.BeginDate).LastOrDefault() : null;
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
            dtStartDate.Value = beginDateNewPeriod;
        }

        /// <summary>
        /// Механізм створення найменування періода залежно від типу
        /// </summary>
        /// <param name="beginDateNewPeriod"></param>
        /// <param name="cntInList"></param>
        private void FormDorpDown(DateTime beginDateNewPeriod, int cntInList = 4)
        {
            // Щомісячно
            int cntMonth = 1;
            string[] quartals = { "I", "II", "III", "IV" };
            string[] halfYear = { "I", "II" };

            // Назва місяця українською
            TextInfo ti = new CultureInfo("uk-UA", false).TextInfo;

            Func<DateTime, string>[] namePeriods = {
                (d)=> ti.ToTitleCase(string.Format( "{0:MMMM} {0:yyyy} року", d )), // Місяць 
                (d)=> ti.ToTitleCase(string.Format( "{0} квартал {1:yyyy} року", d.Month / 3 + 1, d )), // Квартал
                (d)=> ti.ToTitleCase(string.Format( "{0} півріччя {1:yyyy} року", d.Month/6+1, d )), // Півріччя
                (d)=> ti.ToTitleCase(string.Format( "{0:yyyy} рік", d )), // Рік
            };
            Func<DateTime, string> namePariod = namePeriods[0];
            int PeriodCode = 0;
            decimal? MinAmount = 0;
            int[] schemaTypesWhereAmountIsZero = { 2, 3 };

            if ( _licenseAgreement.LicClass == 1 )
            {
                var agree = _licenseAgreement.Agr.AgreementAddBr.Single(rec => rec.Version == _licenseAgreement.Agr.Version);
                PeriodCode = agree.PeriodCode ?? 1;
                MinAmount = 0;
            }
            else
            {
                var agree = _licenseAgreement.LicenseAgrParam.Single(rec => rec.LicVersion == _licenseAgreement.LicVersion);
                PeriodCode = agree.PeriodCode ?? 1;

                var licType = _licenseAgreement.LicCodeNavigation;
                //MinAmount = licType?.SchemaId == 2 ? 0 : agree.MinAmount;
                MinAmount = licType.SchemaId.HasValue && schemaTypesWhereAmountIsZero.Contains(licType.SchemaId.Value) ? 0 : agree.MinAmount;
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
            }

            ddlPeriod.Items.Clear();
            for (int i = 0; i < cntInList; i++)
            {
                var newPeriod = new PaidPeriod
                {
                    Lic = _licenseAgreement,
                    LicId = _licenseAgreement.LicId,
                    BeginDate = beginDateNewPeriod,
                    EndDate = beginDateNewPeriod.AddMonths(cntMonth).AddDays(-1),
                    PeriodName = namePariod(beginDateNewPeriod),
                    PeriodType = PeriodCode,
                    Amount = MinAmount ?? 0,
                    Distribamount = 0,
                    Undistribamount = 0,
                    Status = 1,
                    CustId = _licenseAgreement.CustId.Value,
                    StatusNavigation = dicStatus
                };

                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Text = newPeriod.PeriodName;
                dataItem.Tag = newPeriod;
                ddlPeriod.Items.Add(dataItem);
                beginDateNewPeriod = beginDateNewPeriod.AddMonths(cntMonth);
            }

            ddlPeriod.Items[0].Selected = true;
        }

        bool entry = false;
        private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (entry) return;
            entry = true;

            var begDate = getBeginDate(dtStartDate.Value);
            var firstPeriod = ddlPeriod.Items.Count > 0 ? ddlPeriod.Items[0].Tag as PaidPeriod : null;
            if (begDate != firstPeriod?.BeginDate)
                FormDorpDown(begDate);
            entry = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var check = _licenseAgreement.PaidPeriod.FirstOrDefault(rec => rec.BeginDate == dtStartDate.Value);
            if (check == null)
            {
                var addPeriod = (PaidPeriod)ddlPeriod.SelectedItem.Tag;
                if (_licenseAgreement.PaidPeriod.Count == 0) // firstPeriod
                    addPeriod.FagFirst = true;
                _licenseAgreement.PaidPeriod.Add(addPeriod);
            }

            DialogResult = DialogResult.OK;
        }
    }
}
