using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System.Windows.Forms;
using ipsFormsDesign.Services;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.UI;
using IpsViewComponentLibrary.ConsumerControls;

namespace IpsViewComponentLibrary
{
    public partial class ReportsControl : UserControl
    {
        ExcelEngine _excel = new ExcelEngine();

        public event EventHandler<RegisterRatedList> SaveRegisterRatedListExecuted;
        public event EventHandler<Register> DeleteRegisterExecuted;
        public event EventHandler<List<Register>> SetRegisterStateExecuted;
        public event EventHandler<PaidPeriod> SetPeriodStateExecuted;
        public Func<int, List<RegisterItem>> GetRegisterItems;
        private ButtonEnableControl buttonController;
        private Dictionary<int, PeriodStatus> dicPeriodStatus;
        private Dictionary<int, RegisterStatus> dicRegStatus;
        private Dictionary<int, RegisterListStatus> dicRatedListStatus;

        public ReportsControl()
        {
            InitializeComponent();

            gvPeriodReports.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);
            gvPeriodReports.SetCommandColumnImageAlignment("DeleteColumn", ContentAlignment.MiddleCenter);

            gvRatedList.SetCommandColumnImageAlignment("ViewColumn", ContentAlignment.MiddleCenter);
            buttonController = new ButtonEnableControl(btnAddReport, btnToAcception, btnAccept, btnCreateReport);

            dicPeriodStatus = IpsGlobal.AnketaDictionaties.periodStatus.ToDictionary(rec => rec.CodeI);
            dicRegStatus = IpsGlobal.AnketaDictionaties.registerStatus.ToDictionary(rec => rec.CodeI);
            dicRatedListStatus = IpsGlobal.AnketaDictionaties.registerListStatus.ToDictionary(rec => rec.CodeI);

        }

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                SetupBindings();
            }
        }

        internal void RefreshData()
        {
            normalizeData(_customer);
            gvPeriodReports.MasterTemplate.Refresh();
            gvPeriods.MasterTemplate.Refresh();
            gvLicenseAgr.MasterTemplate.Refresh();
        }

        #region METHODS

        private void normalizeData(Customer cust)
        {
            var dicType = IpsGlobal.AnketaDictionaties.agrLicenseType.ToDictionary(rec => rec.CodeI);
            var dicStatus = IpsGlobal.AnketaDictionaties.agreementStatus.ToDictionary(rec => rec.CodeI);
            var dicPeriod = IpsGlobal.AnketaDictionaties.period.ToDictionary(rec => rec.CodeI);

            foreach (var item in cust.Client.LicenseAgreement)
            {
                item.LicCodeNavigation = dicType[item.LicType ?? 1];

                foreach (var licParam in item.LicenseAgrParam)
                {
                    licParam.Lic = item;
                    licParam.LicStatusNavigation = dicStatus[licParam.LicStatus ?? 1];
                    licParam.PeriodCodeNavigation = dicPeriod[licParam.PeriodCode ?? 1];
                }
                foreach (var period in item.PaidPeriod)
                {
                    period.StatusNavigation = dicPeriodStatus[period.Status];
                    foreach (var link in period.MoneyPeriodLink)
                        link.Period = period;
                    foreach (var regList in period.RegisterRatedList)
                    {
                        regList.Period = period;
                        regList.StatusNavigation = dicRatedListStatus[regList.Status ?? 0];
                        foreach (var reg in regList.Register)
                        {
                            reg.RgStatusNavigation = dicRegStatus[reg.RgStatus ?? 0];
                            reg.RegisterRatedList = regList;
                        }
                    }
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        private void SetupBindings()
        {
            if (_customer == null)
            {
                ClearBindings();
                return;
            }
            normalizeData(_customer);
            var listAgreement = _customer.Client.LicenseAgreement.Where(rec => rec.LicStatus == 2).Select(rec => rec.LicenseAgrParam.Single(item => item.LicVersion == rec.LicVersion));
            bindingLicAgreement.DataSource = listAgreement.Where(rec => rec.LicStatus == 2);
        }

        private void ClearBindings()
        {
            bindingLicAgreement.DataSource = typeof(LicenseAgrParam);
            bindingPaidPeriod.DataSource = typeof(PaidPeriod);
            bindingReports.DataSource = typeof(Register);
        }
        private void CreateAct()
        {
            MessageBox.Show("Створення акту");
        }

        private void ViewAct()
        {
            MessageBox.Show("Перегляд акту");
        }

        #endregion


        #region EVENTS

        // * * * [Активні договори]
        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvLicenseAgr.CurrentRow == null)
                return;

            var lic = gvLicenseAgr.CurrentRow.DataBoundItem as LicenseAgrParam;

            if (lic?.Lic?.PaidPeriod.Count > 0)
                bindingPaidPeriod.DataSource = lic?.Lic?.PaidPeriod?.OrderBy(rec => rec.BeginDate);
            else
                bindingPaidPeriod.DataSource = new List<PaidPeriod>();

            var agrType = IpsGlobal.AnketaDictionaties.agrLicenseType.Single(rec => rec.CodeI == lic.Lic.LicCode);
            /// Цирк,Філармонія,Концертна діяльність
            if ((new int[] { 1, 2, 3, 4 }).Contains((int)agrType.UsesKind))
            {
                splitPanelRatedList.Collapsed = true;
            }
            else
            {
                splitPanelRatedList.Collapsed = false;

            }
        }

        // * * * [Періоди платежів]
        private void gvPeriods_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvPeriods.CurrentRow == null)
                return;

            var period = gvPeriods.CurrentRow.DataBoundItem as PaidPeriod;
            var reports = new List<Register>();
            int maxRgStatus = -1;
            if (period?.RegisterRatedList.Count() > 0)
            {
                foreach (var item in period.RegisterRatedList.OrderBy(rec => rec.RmId))
                {
                    if (item.Register.Count() > 0)
                        maxRgStatus = Math.Max(maxRgStatus, item.Register.Max(rec => rec.RgStatus ?? 0));
                    reports.AddRange(item.Register);
                }
                btnAddRatedList.Enabled = false;
                bindingRatedList.DataSource = period?.RegisterRatedList.First();
            }
            else
            {
                btnAddRatedList.Enabled = true;
                bindingRatedList.DataSource = typeof(RegisterRatedList);
            }

            bindingReports.DataSource = reports;
            buttonController.SetPeriodState(period?.Status, reports);
        }

        // * * * [Звіти періода]
        private void gvPeriodReports_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
        }

        // * * *  * * *  КНОПКИ:
        // * * * НА ГРІД [Періоди платежів]
        private void gvPeriods_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "CreateAct":
                    CreateAct();
                    break;
                case "ViewAct":
                    ViewAct();
                    break;
            }
        }

        private void EnableButtons(bool enabled)
        {
            btnAddReport.Enabled = enabled;
            btnCreateReport.Enabled = enabled;
            //btnViewReport.Enabled = enabled;
            //btnDeleteReport.Enabled = enabled;
        }
        // * * * [Додати звіт]
        private void btnAddReport_Click(object sender, EventArgs e)
        {
            if (gvPeriods.CurrentRow == null)
                return;
            var period = gvPeriods.CurrentRow.DataBoundItem as PaidPeriod;
            if (period == null)
                return;

            OpenFileDialog dialog = new OpenFileDialog { AddExtension = true, DefaultExt = "xlsx", Filter = "Excel Files(*.xlsx;*xls)|*.xls;*.xlsx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                radWaitingBar1.StartWaiting();
                EnableButtons(false);

                var tsk = Task.Run(() =>
                {
                    var list = _excel.GetReportItems(dialog.FileName);
                    if (!period.RegisterRatedList.Any())
                    {
                        period.RegisterRatedList.Add(new RegisterRatedList { PeriodId = period.PeriodId, Period = period, Status = 0 });
                    }

                    var RatedList = period.RegisterRatedList.First();
                    // Створення Звіту
                    Register addRegister = new Register { RgStatus = 0, FileName = Path.GetFileName(dialog.FileName), CustId = _customer.CustId, RgStatusNavigation = dicRegStatus[0] };
                    foreach (var item in list)
                        addRegister.RegisterItem.Add(item);

                    RatedList.Register.Add(addRegister);

                    SaveRegisterRatedListExecuted?.Invoke(this, RatedList);
                    if (!bindingReports.Contains(addRegister))
                        bindingReports.Add(addRegister);

                    BeginInvoke((Action)(() =>
                    {
                        radWaitingBar1.StopWaiting();
                        EnableButtons(true);
                    }));
                });
            }

        }

        /// <summary>
        /// Створити звіт для заповнення вручну
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (gvPeriods?.CurrentRow?.DataBoundItem is PaidPeriod period)
            {
                RegisterRatedList ratedList = null;
                if (!period.RegisterRatedList.Any())
                {
                    ratedList = new RegisterRatedList
                    {
                        PeriodId = period.PeriodId,
                        Period = period,
                        Status = 0,
                        Register = new ObservableListSource<Register>
                        {
                            new Register
                            {
                                RgStatus = 0,
                                FileName = string.Empty,
                                CustId = _customer.CustId,
                                RgStatusNavigation = dicRegStatus[0],
                            }
                        }
                    };
                    period.RegisterRatedList.Add(ratedList);
                }
                else
                {
                    period.RegisterRatedList.SingleOrDefault()?.Register.Add(new Register
                    {
                        RgStatus = 0,
                        FileName = string.Empty,
                        CustId = _customer.CustId,
                        RgStatusNavigation = dicRegStatus[0],
                    });
                }
                var register = period?.RegisterRatedList?.SingleOrDefault()?.Register.LastOrDefault();
                if (register != null)
                {
                    ReportExcelViewForm viewForm = new ReportExcelViewForm(register, true) {
                        StartPosition = FormStartPosition.CenterParent
                    };

                    if (viewForm.ShowDialog() == DialogResult.OK)
                    {
                        SaveRegisterRatedListExecuted?.Invoke(sender, period.RegisterRatedList.SingleOrDefault());
                    }
                    else
                        period.RegisterRatedList.Remove(ratedList);
                }
            }
        }
        // *

        // * * * [Переглянути звіт]
        private void RegisterReport()
        {
            if (GetRegisterItems == null || gvPeriodReports.CurrentRow == null)
                return;
            var register = gvPeriodReports.CurrentRow.DataBoundItem as Register;
            if (register == null)
                return;

            var list = GetRegisterItems(register.RegId);

            register.RegisterItem.Clear();
            list.ForEach(item => register.RegisterItem.Add(item));

            ReportExcelViewForm viewForm = new ReportExcelViewForm(register);
            viewForm.ShowDialog();
        }

        #endregion

        private void DeleteRegister()
        {
            if (GetRegisterItems == null || gvPeriodReports.CurrentRow == null)
                return;
            var register = gvPeriodReports.CurrentRow.DataBoundItem as Register;
            if (register == null)
                return;
            if (MessageBox.Show($"Видалити звіт {register.FileName}", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteRegisterExecuted(this, register);
                var period = gvPeriods.CurrentRow.DataBoundItem as PaidPeriod;
                foreach (var item in period.RegisterRatedList)
                {
                    if (item.Register.Contains(register))
                    {
                        item.Register.Remove(register);
                        break;
                    }


                }
                bindingReports.Remove(register);
                gvPeriodReports.MasterTemplate.Refresh();
            }
        }

        private void gvLicenseAgr_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            var row = e.RowElement.RowInfo;
            var licAgr = row.DataBoundItem as LicenseAgrParam;
            var debt = licAgr?.Lic.PaidPeriod.Where(rec => rec.EndDate < DateTime.Today).Sum(rec => rec.Amount - rec.Undistribamount - rec.Distribamount) ?? 0;
            row.Cells["Arrears"].Value = debt;
        }

        private void gvPeriodReports_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var columnName = e.Column.Name;

            if (columnName == "EditColumn")
            {
                RegisterReport();
            }
            else if (columnName == "DeleteColumn")
            {
                DeleteRegister();
            }
        }

        private void gvPeriodReports_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            string Name = e.Column.Name;
            if (Name == "DeleteColumn" || Name == "EditColumn")
            {
                var register = e.Row.DataBoundItem as Register;
                if (register == null)
                {
                    e.CellElement.Enabled = false;
                }

                else if (register.RgStatus > 0 && Name == "DeleteColumn")
                    e.CellElement.Enabled = false;
                else
                    e.CellElement.Enabled = true;


            }
        }

        private void btnToAcception_Click(object sender, EventArgs e)
        {
            var list = bindingReports.DataSource as List<Register>;
            if (list != null)
            {
                var paramList = list.Where(rec => rec.RgStatus == 0).ToList();
                foreach (var item in paramList)
                    item.RgStatus = 1;
                SetRegisterStateExecuted?.Invoke(this, paramList);
                gvPeriodReports.MasterTemplate.Refresh();
                btnToAcception.Enabled = false;
            }
        }

        /// <summary>
        /// Погодити перелік звітів
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            var period = gvPeriods.CurrentRow.DataBoundItem as PaidPeriod;
            if (period.RegisterRatedList.Sum(rec => rec.Register.Count(item => item.RgStatus < 2)) > 0)
                return;

            period.Status = 2;
            SetPeriodStateExecuted?.Invoke(this, period);

            RefreshData();
        }

        /// <summary>
        /// Створити новий Р/Л
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRatedList_Click(object sender, EventArgs e)
        {
            if (bindingRatedList.Count != 0)
                return;

            var period = gvPeriods.CurrentRow.DataBoundItem as PaidPeriod;

            RegisterRatedList addRatedList = new RegisterRatedList { PeriodId = period.PeriodId, Period = period, Status = 0, StatusNavigation = dicRatedListStatus[0] };
            CreateRatedList form = new CreateRatedList();
            form.RatedList = addRatedList;

            if (form.ShowDialog() == DialogResult.OK)
            {
                period.RegisterRatedList.Add(addRatedList);
                SaveRegisterRatedListExecuted(this, addRatedList);
                bindingRatedList.Add(addRatedList);
                btnAddRatedList.Enabled = false;
            }
        }

        private void gvRatedList_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            var row = e.RowElement.RowInfo;
            if (row == null || row.DataBoundItem == null || !(row.DataBoundItem is RegisterRatedList ))
                return;

            var ratedList = row.DataBoundItem as RegisterRatedList;
            int cnt = ratedList.Register.Count();
            row.Cells["RegisterCount"].Value = cnt;

        }

        private void gvRatedList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if(e.Column.Name == "ViewColumn")
            {
                var row = e.Row;
                var modifyRatedList = row.DataBoundItem as RegisterRatedList;
                CreateRatedList form = new CreateRatedList();
                form.RatedList = modifyRatedList;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    SaveRegisterRatedListExecuted(this, modifyRatedList);
                    bindingRatedList.CurrencyManager.Refresh();
                    btnAddRatedList.Enabled = false;
                }
            }
        }
    }

    /// <summary>
    /// Керування станом кнопок 
    /// </summary>
    class ButtonEnableControl
    {
        private RadButton _addReport,
                          _create,
                          _toAcception,
                          _accepted;

        public ButtonEnableControl(RadButton addReport, RadButton toAcception, RadButton Accepted, RadButton create)
        {
            _addReport = addReport;
            _toAcception = toAcception;
            _accepted = Accepted;
            _create = create;
        }
        public void SetPeriodState(int? state, List<Register> list)
        {
            if (state == null)
            {
                _addReport.Enabled = false;
                _toAcception.Enabled = false;
                _accepted.Enabled = false;
                _create.Enabled = false;
                return;
            }
            int[] regStates = new[] { 0, 0, 0, 0, 0, 0 };
            int countInList = list.Count();
            // Накоплюємо кіль
            foreach (var item in list)
                regStates[item.RgStatus ?? 0]++;

            switch (state)
            {
                case 0: // Новий
                case 1: // Прийом звітів
                case 3: // Борг
                case 4: // Судова робота
                    _addReport.Enabled = true;
                    _create.Enabled = true;
                    _toAcception.Enabled = regStates[0] > 0; // Нових > 0
                    _accepted.Enabled = countInList > 0 && regStates[3] + regStates[2] == countInList; // Всі погоджені
                    break;
                case 2: // Прийом поштів
                case 5: // 
                case 6: // Кошти отримані
                    _addReport.Enabled = false;
                    _toAcception.Enabled = false;
                    _accepted.Enabled = false;
                    _create.Enabled = false;
                    break;
                default: // Зактритий
                    _addReport.Enabled = false;
                    _toAcception.Enabled = false;
                    _accepted.Enabled = false;
                    _create.Enabled = false;
                    break;
            }
        }

    }
    public class GridPeriodsR
    {
        public int PeriodId { get; set; }
        public string PeriodName { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public decimal Distribamount { get; set; }
        public int ReportCounts { get; set; }
        public string IsActFormed { get; set; }
    }

    public class GridReportsP
    {
        public int ReportId { get; set; }
        public string PeriodName { get; set; }
        public string ReportsName { get; set; }
        public string PathString { get; set; }
    }
}
