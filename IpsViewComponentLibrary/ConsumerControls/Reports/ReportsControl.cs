using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ConsumerControls.Reports.Forms;
using IpsViewComponentLibrary.ConsumerDialogForms;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.InternalControlsModel;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.Reports
{
    /*
     * в контролі наявний WaitingBar;
     */

    public partial class ReportsControl : UserControl
    {
        private const string SaveReportSuccessMsg = "Звіт збережено!";
        private const string SaveReportErrorMsg = "Неможливо зберегти звіт!";

        private const string LoadReportFromFileSuccessMsg = "Новий звіт додано!";
        private const string LoadReportFromFileErrorMsg = "Неможливо додати звіт!";

        private const string DeleteRegisterSuccessMsg = "Звіт видалено!";
        private const string DeleteRegisterErrorMsg = "Неможливо видалити звіт!";

        private readonly ExcelEngine _excel = ExcelEngine.GetInstance();

        public event Func<RegisterRatedList, bool> SaveRegisterRatedListExecuted;
        public event Func<Register, bool> DeleteRegisterExecuted;
        public event Func<Register, bool> SaveRegisterExecuted;
        public event EventHandler<List<Register>> SetRegisterStateExecuted;
        public event EventHandler<PaidPeriod> SetPeriodStateExecuted;
        public event EventHandler<List<PaidPeriod>> SavePariodCommandExecuted;
        public event UpdateCustomerDataEventHandler UpdateData;

        public Func<int, List<RegisterItem>> GetRegisterItems;
        private readonly ButtonEnableControl buttonController;
        private Dictionary<int, PeriodStatus> dicPeriodStatus;
        private Dictionary<int, RegisterStatus> dicRegStatus;
        private Dictionary<int, RegisterListStatus> dicRatedListStatus;
        private TypeRights _typeRights = TypeRights.All;
        private List<int> validClass;
        private Customer _customer;

        // керування зміною поточного активного договору
        private CurrentAgreementController _currentAgreementController = null;

        public ReportsControl()
        {
            InitializeComponent();

            gvPeriodReports.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);
            gvPeriodReports.SetCommandColumnImageAlignment("DeleteColumn", ContentAlignment.MiddleCenter);

            gvRatedList.SetCommandColumnImageAlignment("ViewColumn", ContentAlignment.MiddleCenter);
            buttonController = new ButtonEnableControl(btnAddReport, btnToAcception, btnAcceptType1, btnAcceptType2, btnCreateReport);

            if (IpsGlobal.AnketaDictionaties != null)
                SubscribeDictionary(null, null);
            else
                IpsGlobal.AnketaDictionatiesChanged += SubscribeDictionary;
        }

        public Customer Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                SetupBindings();
            }
        }

        [EditorBrowsable]
        public CurrentAgreementController CurrentAgreementController
        {
            get => _currentAgreementController;
            set
            {
                if (_currentAgreementController != null)
                    _currentAgreementController.CurrentLicenseAgreementChanged -= _currentAgreementController_CurrentLicenseAgreementChanged;
                _currentAgreementController = value;
                if (_currentAgreementController != null)
                    _currentAgreementController.CurrentLicenseAgreementChanged += _currentAgreementController_CurrentLicenseAgreementChanged;
            }
        }

        private void _currentAgreementController_CurrentLicenseAgreementChanged(object sender, LicenseAgreement e)
        {
            if (sender == this) return;
            var lic = ActiveAgreementDataFactory.CreateAgreementData(e);
            var row = gvLicenseAgr.Rows.FirstOrDefault(rec => (rec.DataBoundItem as IAgreementData)?.Lic.LicId == e.LicId);


            if (row != null)
            {
                if (row.IsCurrent == false)
                {
                    row.IsCurrent = true;
                    // if (row.IsVisible == false) row.IsVisible = true;
                }
            }
        }

        [EditorBrowsable]
        public TypeRights TypeRights { get => _typeRights; set { _typeRights = value; ReinitValidClass(); } }

        private void ReinitValidClass()
        {
            validClass = new List<int>();
            if (TypeRights == TypeRights.SmallRights || TypeRights == TypeRights.All)
                validClass.Add(0);
            if (TypeRights == TypeRights.BigRights || TypeRights == TypeRights.All)
                validClass.Add(1);

        }

        private void SubscribeDictionary(object sender, EventArgs args)
        {
            dicPeriodStatus = IpsGlobal.AnketaDictionaties.periodStatus.ToDictionary(rec => rec.CodeI);
            dicRegStatus = IpsGlobal.AnketaDictionaties.registerStatus.ToDictionary(rec => rec.CodeI);
            dicRatedListStatus = IpsGlobal.AnketaDictionaties.registerListStatus.ToDictionary(rec => rec.CodeI);

        }

        public void RefreshData()
        {
            NormalizeData(_customer);
            bindingReports.ResetBindings(false);
            if (gvLicenseAgr.CurrentRow?.DataBoundItem is IAgreementData lic)
            {
                if (lic.Lic?.PaidPeriod != null && lic.Lic.PaidPeriod.Count > 0)
                {
                    var listPaidPeriod = lic.Lic.PaidPeriod.OrderBy(rec => rec.BeginDate).ToList();
                    bsPaidPeriod.DataSource = ReportPaidPeriod.Convert(listPaidPeriod);
                }
                else
                    bsPaidPeriod.DataSource = typeof(ReportPaidPeriod);
            }

            bsPaidPeriod.ResetBindings(false);
            gvPeriodReports.MasterTemplate.Refresh();
        }

        #region METHODS

        private void NormalizeData(Customer cust)
        {
            var dicType = IpsGlobal.AnketaDictionaties.agrLicenseType.ToDictionary(rec => rec.CodeI);
            var dicStatus = IpsGlobal.AnketaDictionaties.agreementStatus.ToDictionary(rec => rec.CodeI);
            var dicPeriod = IpsGlobal.AnketaDictionaties.period.ToDictionary(rec => rec.CodeI);

            foreach (var item in cust.Client.LicenseAgreement)
            {
                item.LicCodeNavigation = dicType[item.LicCode];

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
                            reg.Rm = regList;
                        }
                    }
                }
            }
        }

        private void SetupBindings()
        {
            if (_customer == null)
            {
                ClearBindings();
                return;
            }
            NormalizeData(_customer);
            if (validClass == null)
                ReinitValidClass();

            var listAgreement = _customer.Client.LicenseAgreement.Where(rec => rec.LicStatus == 2 && rec.LicClass != 1 && validClass.Contains(rec.LicClass))
                            .Select(rec => ActiveAgreementDataFactory.CreateAgreementData(rec)).ToList();
            bindingAgreement.DataSource = listAgreement;
        }

        private void ClearBindings()
        {
            bindingAgreement.DataSource = typeof(IAgreementData);
            bsPaidPeriod.DataSource = typeof(ReportPaidPeriod);
            bindingReports.DataSource = typeof(Register);
            buttonController.SetPeriodState(null, null);
            btnAddRatedList.Enabled = false;

        }

        #endregion


        #region EVENTS

        // * * * [Активні договори]
        private void GvLicenseAgr_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {

            if (!(gvLicenseAgr.CurrentRow?.DataBoundItem is IAgreementData lic))
            {
                bsPaidPeriod.DataSource = typeof(ReportPaidPeriod);
                return;
            }

            if (lic.Lic?.PaidPeriod.Count > 0)
            {
                var listPaidPeriod = lic.Lic?.PaidPeriod?.OrderBy(rec => rec.BeginDate).ToList();
                bsPaidPeriod.DataSource = ReportPaidPeriod.Convert(listPaidPeriod);

            }
            else
            {
                bsPaidPeriod.DataSource = typeof(ReportPaidPeriod);
                buttonController.SetPeriodState(null, null);
            }

            var agrType = IpsGlobal.AnketaDictionaties.agrLicenseType.SingleOrDefault(rec => rec.CodeI == lic.Lic.LicCode);
            // Цирк,Філармонія,Концертна діяльність
            bool isCollapsed = agrType?.SchemaId == 2;
            // AddReport Xls disable for Цирк, Філармонія, Концертна діяльність
            btnAddReport.Enabled = !isCollapsed;

            splitPanelRatedList.Collapsed = !isCollapsed;
            btnAcceptType1.Visible = splitPanelRatedList.Collapsed;
            if (CurrentAgreementController != null && !CurrentAgreementController.Broadcast && lic.Lic?.LicId != CurrentAgreementController.LicId)
            {
                CurrentAgreementController.ChangeCurrentLicenseAgreement(this, lic.Lic);
            }
        }

        // * * * [Періоди платежів]
        private void GvPeriods_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (!(gvPeriods.CurrentRow?.DataBoundItem is PaidPeriod period))
            {
                bindingRatedList.DataSource = typeof(RegisterRatedList);
                bindingReports.DataSource = typeof(Register);
                return;
            }

            //var period = (PaidPeriod)gvPeriods.CurrentRow.DataBoundItem;
            var reports = new List<Register>();
            int maxRgStatus = -1;
            if (period.RegisterRatedList.Any())
            {
                foreach (var item in period.RegisterRatedList.OrderBy(rec => rec.RmId))
                {
                    if (item.Register.Any())
                        maxRgStatus = Math.Max(maxRgStatus, item.Register.Max(rec => rec.RgStatus ?? 0));
                    reports.AddRange(item.Register);
                }
                btnAddRatedList.Enabled = false;
                bindingRatedList.DataSource = period.RegisterRatedList.First();
            }
            else
            {
                btnAddRatedList.Enabled = true;
                bindingRatedList.DataSource = typeof(RegisterRatedList);
            }

            bindingReports.DataSource = reports;
            buttonController.SetPeriodState(period.Status, reports);
            
            if (gvLicenseAgr.CurrentRow?.DataBoundItem is IAgreementData lic)
            {
                var agrType = IpsGlobal.AnketaDictionaties.agrLicenseType.SingleOrDefault(rec => rec.CodeI == lic.Lic.LicCode);
                btnAddReport.Enabled = agrType?.SchemaId != 2;
            }
        }

        private void gvPeriodReports_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (!(e.CurrentRow?.DataBoundItem is Register register))
                return;

            btnToAcception.Enabled = register.RgStatus == 0 || register.RgStatus == 5;
        }

        // * * *  * * *  КНОПКИ:
        // * * * НА ГРІД [Періоди платежів]
        private void GvPeriods_CommandCellClick(object sender, GridViewCellEventArgs e)
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

        private void CreateAct()
        {
            MessageBox.Show("Створення акту");
        }

        private void ViewAct()
        {
            MessageBox.Show("Перегляд акту");
        }

        private void EnableButtons(bool enabled)
        {
            btnAddReport.Enabled = enabled;
            btnCreateReport.Enabled = enabled;
            //btnViewReport.Enabled = enabled;
            //btnDeleteReport.Enabled = enabled;
        }

        // * * * [Додати звіт]
        private async void BtnAddReport_Click(object sender, EventArgs e)
        {
            if (!(gvPeriods?.CurrentRow?.DataBoundItem is PaidPeriod period))
                return;

            var dialog = new OpenFileDialog { AddExtension = true, DefaultExt = "xlsx", Filter = "Excel Files(*.xlsx;*xls)|*.xls;*.xlsx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var licenseAgreement = _customer.Client.LicenseAgreement.FirstOrDefault(rec => rec.LicId == period.LicId);
                EnableButtons(false);

                Register addRegister = null;
                bool statusDoubledRecordExist = false;
                bool result = false;

                string identityName = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity?.Name;

                waitingBar.StartWaiting();
                await Task.Factory.StartNew(() =>
                {
                    var list = _excel.GetReportItems(dialog.FileName);
                    statusDoubledRecordExist = ReportsHandler.CheckDoubleRecord(list);
                    if (!statusDoubledRecordExist)
                    {
                        if (!period.RegisterRatedList.Any())
                        {
                            period.RegisterRatedList.Add(new RegisterRatedList
                            {
                                PeriodId = period.PeriodId,
                                Period = period,
                                Status = 0
                            });
                        }

                        var RatedList = period.RegisterRatedList.First();
                        // Створення Звіту
                        addRegister = new Register
                        {
                            RgStatus = 0,
                            FileName = Path.GetFileName(dialog.FileName),
                            CustId = _customer.CustId,
                            RgStatusNavigation = dicRegStatus[0],
                            PeriodId = period.PeriodId,
                            Rm = RatedList,
                            LicId = period.LicId,
                            SchemaId = licenseAgreement?.LicCodeNavigation?.SchemaId ?? 1,
                            AlgorithmId = licenseAgreement?.LicCodeNavigation?.AlgorithmId ?? 1,
                            UserId = identityName
                        };

                        foreach (var item in list)
                            addRegister.RegisterItem.Add(item);

                        RatedList.Register.Add(addRegister);
                        result = SaveRegisterRatedListExecuted?.Invoke(RatedList) ?? false;
                    }
                })
                .ContinueWith(tsk => {

                    if (tsk.Status == TaskStatus.RanToCompletion && addRegister != null && !bindingReports.Contains(addRegister))
                        bindingReports.Add(addRegister);

                    EnableButtons(true);
                    btnToAcception.Enabled = true;
                }, TaskScheduler.FromCurrentSynchronizationContext());

                waitingBar.StopWaiting();

                if (!statusDoubledRecordExist)
                    MessageShow.ShowInfoByResult(LoadReportFromFileSuccessMsg, LoadReportFromFileErrorMsg, result);
            }

            RefreshData();
        }

        /// <summary>
        /// Створити звіт для заповнення вручну
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateReport_Click(object sender, EventArgs e)
        {
            if (!(gvPeriods?.CurrentRow?.DataBoundItem is PaidPeriod period))
                return;

            string identityName = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity?.Name;

            if (!period.RegisterRatedList.Any())
            {
                period.RegisterRatedList.Add(new RegisterRatedList { PeriodId = period.PeriodId, Period = period, Status = 0 });
            }

            var algorithmId = (gvLicenseAgr.CurrentRow.DataBoundItem as IAgreementData)?.Lic?.LicCodeNavigation?.AlgorithmId;
            var schemaId = (gvLicenseAgr.CurrentRow.DataBoundItem as IAgreementData)?.Lic?.LicCodeNavigation?.SchemaId;

            //об'єкт звіт
            var registerTemp = new Register
            {
                RgStatus = 0,
                RmId = period.RegisterRatedList.SingleOrDefault()?.RmId ?? 0,
                FileName = string.Empty,
                CustId = _customer.CustId,
                RgStatusNavigation = dicRegStatus[0],
                LicId = period.LicId,
                AlgorithmId = algorithmId,
                PeriodId = period.PeriodId,
                SchemaId = schemaId,
                UserId = identityName,
            };
            
            // рапортичка
            if (schemaId == 2)
            {
                var progReportBigRight = new ReportExtendedForm(registerTemp)
                {
                    HeaderInfoCustomerName = GetCustomerName(),
                    HeaderInfoLicenseNumberString = ((IAgreementData)gvLicenseAgr.CurrentRow.DataBoundItem).AgrNumber,
                    HeaderInfoPeriodName = period.PeriodName,
                    HeaderInfoRatedListNumber = period.RegisterRatedList.SingleOrDefault()?.RmId.ToString()
                };

                if (progReportBigRight.ShowDialog() == DialogResult.OK)
                {
                    period.RegisterRatedList.SingleOrDefault()?.Register.Add(registerTemp);
                    bindingReports.Add(registerTemp);

                    var result = SaveRegisterRatedListExecuted?.Invoke(period.RegisterRatedList.SingleOrDefault()) ?? false;
                    MessageShow.ShowInfoByResult(SaveReportSuccessMsg, SaveReportErrorMsg, result);
                }
            }
            // не рапотричка
            else
            {
                var viewForm = new ReportExcelForm(registerTemp, true);
                if (viewForm.ShowDialog() == DialogResult.OK)
                {
                    period.RegisterRatedList.SingleOrDefault()?.Register.Add(registerTemp);
                    bindingReports.Add(registerTemp);
                    var result = SaveRegisterRatedListExecuted?.Invoke(period.RegisterRatedList.SingleOrDefault()) ?? false;
                    MessageShow.ShowInfoByResult(SaveReportSuccessMsg, SaveReportErrorMsg, result);
                }
            }

            RefreshData();
        }

        /// <summary>
        ///  Найменування користувача
        /// </summary>
        /// <returns></returns>
        private string GetCustomerName()
        {
            string customerName;
            if (_customer.CustType == 3)
            {
                customerName = _customer.Company?.AnketaCompany?.SingleOrDefault()?.ShortName;
            }
            else
            {
                var anketaPerson = _customer.Person?.AnketaPerson?.SingleOrDefault();
                customerName = $"{anketaPerson?.LastName} {anketaPerson?.FirstName} {anketaPerson?.SurName}";
            }

            return customerName;
        }

        #endregion

        private void GvPeriodReports_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var columnName = e.Column.Name;

            if (columnName == "EditColumn")
            {
                OpenRegisterForView();
            }
            else if (columnName == "DeleteColumn")
            {
                DeleteRegister();
                RefreshData();
            }
        }

        /// <summary>
        /// Переглянути звіт
        /// </summary>
        private void OpenRegisterForView()
        {
            if (GetRegisterItems == null || !(gvPeriodReports.CurrentRow?.DataBoundItem is Register register))
                return;

            var period = gvPeriods?.CurrentRow?.DataBoundItem as PaidPeriod;
            var reg = period?.RegisterRatedList?.SingleOrDefault()?.Register.SingleOrDefault(r => r.RmId == register.RmId && r.RegId == register.RegId);
            var schemaId = (gvLicenseAgr.CurrentRow.DataBoundItem as IAgreementData)?.Lic?.LicCodeNavigation?.SchemaId;

            var list = GetRegisterItems(register.RegId);

            register.RegisterItem.Clear();
            list.ForEach(item => register.RegisterItem.Add(item));

            if (reg != null && (schemaId == 2 || schemaId == 3)) // рапортичка
            {
                var progReportBigRight = new ReportExtendedForm(register, (register.RgStatus == 0 || register.RgStatus == 5))
                {
                    HeaderInfoCustomerName = GetCustomerName(),
                    HeaderInfoLicenseNumberString = ((IAgreementData)gvLicenseAgr.CurrentRow.DataBoundItem).AgrNumber,
                    HeaderInfoPeriodName = period.PeriodName,
                    HeaderInfoRatedListNumber = period.RegisterRatedList.SingleOrDefault()?.RmId.ToString()
                };

                if (progReportBigRight.ShowDialog() == DialogResult.OK)
                {
                    var result = SaveRegisterExecuted?.Invoke(register) ?? false;
                    MessageShow.ShowInfoByResult(SaveReportSuccessMsg, SaveReportErrorMsg, result);
                }
                return;
            }

            var viewForm = new ReportExcelForm(register, (register.RgStatus == 0 || register.RgStatus == 5));
            if (viewForm.ShowDialog() == DialogResult.OK)
            {
                var result = SaveRegisterExecuted?.Invoke(register) ?? false;
                MessageShow.ShowInfoByResult(SaveReportSuccessMsg, SaveReportErrorMsg, result);
            }
        }

        /// <summary>
        /// Видалити звіт
        /// </summary>
        private void DeleteRegister()
        {
            if (GetRegisterItems == null)
                return;

            if (!(gvPeriodReports.CurrentRow?.DataBoundItem is Register register))
                return;

            if (MessageShow.ConfirmAction($"Видалити звіт \"{register.FileName}\"?") == DialogResult.Yes)
            {
                var period = gvPeriods.CurrentRow.DataBoundItem as PaidPeriod;
                var result = DeleteRegisterExecuted?.Invoke(register) ?? false;
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
                MessageShow.ShowInfoByResult(DeleteRegisterSuccessMsg, DeleteRegisterErrorMsg, result);
            }
        }

        private void GvPeriodReports_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            string Name = e.Column.Name;
            int[] EditingStatus = { 0, 5 };
            if (Name == "DeleteColumn" || Name == "EditColumn")
            {
                if (!(e.Row.DataBoundItem is Register register))
                {
                    e.CellElement.Enabled = false;
                }

                else if (!EditingStatus.Contains(register.RgStatus ?? 0) && Name == "DeleteColumn")
                    e.CellElement.Enabled = false;
                else
                    e.CellElement.Enabled = true;
            }
        }

        private void BtnToAcception_Click(object sender, EventArgs e)
        {
            if (bindingReports.DataSource is List<Register> list)
            {
                // MED-682 *** begin Патлякевич 
                //var paramList = list.Where(rec => rec.RgStatus == 0).ToList();
                var paramList = new List<Register>();
                if (bindingReports.Current is Register @curRow)
                {
                    paramList.Add(@curRow);
                // MED-682 *** end 
                    var regStatus = dicRegStatus[1];
                    foreach (var item in paramList)
                    {
                        item.RgStatus = 1;
                        item.RgStatusNavigation = regStatus;
                    }
                }
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
        private void BtnAccept_Click(object sender, EventArgs e)
        {
            var period = gvPeriods.CurrentRow.DataBoundItem as PaidPeriod;
            if (period.RegisterRatedList.Sum(rec => rec.Register.Count(item => item.RgStatus < 2)) > 0)
                return;

            period.Status = 2;
            period.StatusNavigation = dicPeriodStatus[2];
            SetPeriodStateExecuted?.Invoke(this, period);
            btnAcceptType1.Enabled = false;
            RefreshData();
        }

        /// <summary>
        /// Створити новий Р/Л
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddRatedList_Click(object sender, EventArgs e)
        {
            if (bindingRatedList.Count != 0)
                return;

            var period = gvPeriods.CurrentRow.DataBoundItem as PaidPeriod;

            var addRatedList = new RegisterRatedList { PeriodId = period.PeriodId, Period = period, Status = 0, StatusNavigation = dicRatedListStatus[0] };
            var form = new CreateRatedList
            {
                RatedList = addRatedList
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                period.RegisterRatedList.Add(addRatedList);
                var result = SaveRegisterRatedListExecuted?.Invoke(addRatedList);
                bindingRatedList.Add(addRatedList);
                btnAddRatedList.Enabled = false;
            }
        }

        private void GvRatedList_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (!(e.RowElement?.RowInfo?.DataBoundItem is RegisterRatedList ratedList))
                return;
            
            e.RowElement.RowInfo.Cells["RegisterCount"].Value = ratedList.Register.Count;
        }

        private void GvRatedList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ViewColumn")
            {
                var row = e.Row;
                var modifyRatedList = row.DataBoundItem as RegisterRatedList;
                var form = new CreateRatedList
                {
                    RatedList = modifyRatedList
                };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    var result = SaveRegisterRatedListExecuted?.Invoke(modifyRatedList);
                    bindingRatedList.CurrencyManager.Refresh();
                    btnAddRatedList.Enabled = false;
                }
            }
        }

        private void BtnAddPeriod_Click(object sender, EventArgs e)
        {
            if (!(gvLicenseAgr.CurrentRow?.DataBoundItem is IAgreementData))
                return;
            var lic = (gvLicenseAgr.CurrentRow.DataBoundItem as IAgreementData).Lic;
            CreatePeriod form = new CreatePeriod(lic);

            if (form.ShowDialog() == DialogResult.OK)
            {
                var list = lic.PaidPeriod.ToList();
                SavePariodCommandExecuted?.Invoke(this, list);
                bsPaidPeriod.DataSource = ReportPaidPeriod.Convert(list);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData?.Invoke(_customer.CustId);
            SetupBindings();
        }
    }
}
