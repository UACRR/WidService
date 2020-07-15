using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IpsCommonTypes.SQLViews;
using IPSComponentLibrary.Forms.Register;
using ipsFormsDesign;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight.Cabinet
{
    public partial class CalculationControl : UserControl
    {
        private bool _isRunFromDragDrop;

        private readonly ButtonController buttonController;
        private readonly GridStateRecorder _stateRecorder = new GridStateRecorder();

        public event EmptyEventHandler UpdateData;

        public CalculationControl()
        {
            InitializeComponent();

            gvPrepays.CellFormatting += (o, e) =>
            {
                if (e.Column.FieldName.Equals("action", StringComparison.OrdinalIgnoreCase))
                {
                    RadButtonElement btn = ((GridCommandCellElement)e.CellElement).CommandButton;
                    btn.Text = "Зарахувати виплату";
                }
            };

            SetupDragDrop();

            buttonController = new ButtonController(btnNewPeriod, btnDistribute, btnClosePeriod);
            _stateRecorder.AddGrid(gvUserMoneys);
            _stateRecorder.AddGrid(gvLicenseAgr);
            _stateRecorder.AddGrid(gvPeriodsPayment);
        }

        private int CustId { get; set; }
        
        private ObservableListSource<MoneyReceived> MoneyReceivedList { get; set; }
        
        private LicenseAgreement LicenseAgreement { get; set; }

        private List<QUERY_RegisterPrepayAmountSum> RegisterPrepayAmountSumList { get; set; }

        public async void SetDataByCustId(int custId)
        {
            CustId = custId;

            var service = CalculationBRService.GetInstance();

            LicenseAgreement = await service.GetLicenseAgreementAsync(custId);
            NormalizeData(LicenseAgreement);

            var response  = await service.GetPrepayAmountAsync(LicenseAgreement.LicId);
            RegisterPrepayAmountSumList = response.Data;

            var moneyPrepaysList = await service.GetMoneyPrepayListAsync(custId);
            bsCalculationPrepaysModel.DataSource = moneyPrepaysList;

            MoneyReceivedList = await service.GetMoneyReceivedListAsync(custId);

            SetupAllBinding();
        }

        /// <summary>
        /// Доповнити даними системними словниками
        /// </summary>
        /// <param name="licenseAgreement"></param>
        private void NormalizeData(LicenseAgreement licenseAgreement)
        {
            var dicType = IpsGlobal.AnketaDictionaties.agrLicenseType.ToDictionary(rec => rec.CodeI);
            var dicStatus = IpsGlobal.AnketaDictionaties.agreementStatus.ToDictionary(rec => rec.CodeI);
            var dicPeriod = IpsGlobal.AnketaDictionaties.period.ToDictionary(rec => rec.CodeI);
            var dicPeriodStatus = IpsGlobal.AnketaDictionaties.periodStatus.ToDictionary(rec => rec.CodeI);

            licenseAgreement.LicCodeNavigation = dicType[licenseAgreement.LicCode];

            foreach (var licParam in licenseAgreement.LicenseAgrParam)
            {
                licParam.Lic = licenseAgreement;
                licParam.LicStatusNavigation = dicStatus[licParam.LicStatus ?? 1];
                licParam.PeriodCodeNavigation = dicPeriod[licParam.PeriodCode ?? 1];
            }

            foreach (var period in licenseAgreement.PaidPeriod)
            {
                period.StatusNavigation = dicPeriodStatus[period.Status];
                period.Lic = licenseAgreement;
                foreach (var link in period.MoneyPeriodLink)
                    link.Period = period;
            }
        }

        #region * * * Drag & Drop logic * * *

        private GridDataRowElement dragRow;
        private GridDataRowElement dropRow;
        private readonly List<KeyValuePair<Type, Type>> validDragDrop = new List<KeyValuePair<Type, Type>>
        {
            new KeyValuePair<Type, Type>(typeof(MoneyReceived), typeof(IAgreementData)),
            new KeyValuePair<Type, Type>(typeof(MoneyReceived), typeof(PaidPeriod)),
            new KeyValuePair<Type, Type>(typeof(PaidPeriod), typeof(MoneyReceived)),
            new KeyValuePair<Type, Type>(typeof(IAgreementData), typeof(MoneyReceived)),
        };

        private void SetupDragDrop()
        {
            SubscribeForGridEvents(gvUserMoneys, gvLicenseAgr);
            SubscribeForGridEvents(gvLicenseAgr, gvUserMoneys);
            SubscribeForGridEvents(gvPeriodsPayment, gvUserMoneys);
        }

        private void SubscribeForGridEvents(RadGridView grid, RadGridView GridTarget)
        {
            var dragDropService = grid.GridViewElement.GetService<RadDragDropService>();
            dragDropService.PreviewDragOver += DragDropService_PreviewDragOver;
            dragDropService.PreviewDragDrop += DragDropService_PreviewDragDrop;
            dragDropService.PreviewDragStart += DragDropService_PreviewDragStart;

            var behavior = grid.GridBehavior as BaseGridBehavior;
            grid.GridBehavior = behavior;

            behavior.UnregisterBehavior(typeof(GridViewDataRowInfo));
            behavior.RegisterBehavior(typeof(GridViewDataRowInfo), new RowSelectionGridBehavior(GridTarget));
        }

        /// <summary>
        /// Старт процедури DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragDropService_PreviewDragStart(object sender, PreviewDragStartEventArgs e)
        {
            var target = e.DragInstance as RadItem;

            if (!(target is GridDataRowElement row))
                return;

            dragRow = row;
            dropRow = null;

            if (row.RowInfo.DataBoundItem is PaidPeriod period)
                e.CanStart = ValidPeriodForPay(period);
            else if (row.RowInfo.DataBoundItem is IAgreementData licAgr)
                e.CanStart = ValidLicAgrForPay(licAgr);
            else
                e.CanStart = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragDropService_PreviewDragDrop(object sender, RadDropEventArgs e)
        {
            if (!(e.HitTarget is RadItem dropTarget))
                return;

            //RadGridView targetGrid = dropTarget.ElementTree.Control as RadGridView;
            var dropTargetRow = dropTarget as GridDataRowElement;
            dropRow = dropTargetRow;

            KeyValuePair<Type, Type> search = new KeyValuePair<Type, Type>(dragRow.RowInfo.DataBoundItem.GetType(), dropRow.RowInfo.DataBoundItem.GetType());

            if (!validDragDrop.Exists(row => row.Key.IsAssignableFrom(search.Key) && row.Value.IsAssignableFrom(search.Value)))
                return;

            _isRunFromDragDrop = true;
            e.Handled = true;

            ddBtnAction.BeginInvoke((Action)(() => btnDistribute.PerformClick()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragDropService_PreviewDragOver(object sender, RadDragOverEventArgs e)
        {
            if (e.DragInstance is GridDataRowElement && e.HitTarget is GridDataRowElement)
            {
                RadItem dropTarget = e.HitTarget as RadItem;
                RadGridView targetGrid = dropTarget.ElementTree.Control as RadGridView;
                GridDataRowElement hitRow = dropTarget as GridDataRowElement;

                if (hitRow.RowInfo.DataBoundItem.GetType() == dragRow.RowInfo.DataBoundItem.GetType())
                    return;

                var search = new KeyValuePair<Type, Type>(dragRow.RowInfo.DataBoundItem.GetType(), hitRow.RowInfo.DataBoundItem.GetType());
                if (!validDragDrop.Exists(row => row.Key.IsAssignableFrom(search.Key) && row.Value.IsAssignableFrom(search.Value)))
                    return;

                if (hitRow.RowInfo.DataBoundItem is PaidPeriod period)
                    e.CanDrop = ValidPeriodForPay(period);
                else if (hitRow.RowInfo.DataBoundItem is IAgreementData lic)
                    e.CanDrop = ValidLicAgrForPay(lic);
                else
                    e.CanDrop = true;
            }
        }

        /// <summary>
        /// Перевірка можливості оплати Ліцензійного договору
        /// </summary>
        /// <param name="licAgr"></param>
        /// <returns></returns>
        private bool ValidLicAgrForPay(IAgreementData licAgr)
        {
            if (licAgr.Lic.LicStatus != 2)
                return false;

            foreach (var period in licAgr.Lic.PaidPeriod)
            {
                bool checkPeriod = ValidPeriodForPay(period);
                if (checkPeriod) return true;
            }

            return false;
        }

        /// <summary>
        /// Перевірка звітів періода, які можна оплатити
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        private bool ValidPeriodForPay(PaidPeriod period)
        {
            // Прийом звітів
            if (period.Status == 1)
                return false;
            
            // Беремо тільки Погоджені РЛ
            var rrl = period.RegisterRatedList.Where(rec => rec.Status == 1).ToList();

            // Сумуємо кількість звітів, які можно оплачувати
            var cnt = rrl.Sum(rec => rec.Register.Count(reg => ((reg.AuthAmount ?? 0) + (reg.MusicAmount ?? 0) == 0 || (reg.PaidAmount ?? 0) == 0)));
            return cnt > 0;
        }

        #endregion

        private void SetupAllBinding()
        {
            // платежі користувача
            var list = MoneyReceivedList.Where(rec => rec.Amount > (rec.DestribAmount + (rec.DestribPrepay ?? 0))).ToList();
            bsAllMoneyReceived.DataSource = !list.Any() ? (object)typeof(MoneyReceived) : list;

            // ген угода
            var agreementData = ActiveAgreementDataFactory.CreateAgreementData(LicenseAgreement);
            var agreementDataList = new ObservableListSource<IAgreementData> { agreementData };
            bsLicAgreement.DataSource = agreementDataList;

            // список періодів
            if (gvLicenseAgr.CurrentRow != null)
            {
                var licItem = (IAgreementData)gvLicenseAgr.CurrentRow.DataBoundItem;
                var periodList = licItem.Lic?.PaidPeriod.OrderBy(rec => rec.BeginDate).ToList();
                bsPaidPeriod.DataSource = periodList;

                foreach (var row in gvPeriodsPayment.Rows)
                {
                    var periodId = (int)row.Cells["PeriodId"].Value;
                    var item = RegisterPrepayAmountSumList?.FirstOrDefault(rec => rec.PeriodId == periodId);
                    row.Cells["PrepaySum"].Value = item?.PrepayAmountSum;
                }
            }
            else
            {
                bsPaidPeriod.DataSource = typeof(PaidPeriod);
            }
        }

        /// <summary>
        /// Додати період
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnNewPeriod_Click(object sender, EventArgs e)
        {
            var currentAgree = gvLicenseAgr.CurrentRow.DataBoundItem as IAgreementData;
            var dialog = new CreatePeriod(currentAgree.Lic);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var service = CalculationBRService.GetInstance();

                var result = await service.CreatePeriodAsync(dialog.CretaedPaidPeriod);

                if (result.IsSuccess)
                {
                    ShowMessage.ShowInfo("Новий період створено!");
                }
                else
                {
                    if (result.HasException)
                        ShowMessage.ShowError(result.Exception);
                    else
                        ShowMessage.ShowError("Неможливо створити новий період!");
                }

                UpdateData?.Invoke();
            }
        }

        /// <summary>
        /// Прив'язати суму до періоду
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDistribute_Click(object sender, EventArgs e)
        {
            MoneyReceived pay = null;
            IAgreementData licParam = null;
            PaidPeriod period = null;
            if (_isRunFromDragDrop)
            {
                GridDataRowElement payRow = null,
                                   destRow = null;

                if (dragRow.RowInfo.DataBoundItem is MoneyReceived)
                {
                    payRow = dragRow;
                    destRow = dropRow;
                }
                else
                {
                    payRow = dropRow;
                    destRow = dragRow;
                }

                pay = payRow.RowInfo.DataBoundItem as MoneyReceived;
                if (destRow.RowInfo.DataBoundItem is PaidPeriod paidPeriod) // Drop to PaidPeriod
                {
                    period = paidPeriod;
                    licParam = ActiveAgreementDataFactory.CreateAgreementData(period.Lic);
                }
                else // Drop to LicenceAgreement
                {
                    licParam = (destRow.RowInfo.DataBoundItem as IAgreementData);
                    period = null;
                }

                _isRunFromDragDrop = false;
            }
            else
            {
                if (gvUserMoneys.CurrentRow == null || gvLicenseAgr.CurrentRow == null)
                    return;

                pay = gvUserMoneys.CurrentRow.DataBoundItem as MoneyReceived;
                licParam = gvLicenseAgr.CurrentRow.DataBoundItem as IAgreementData;
                period = gvPeriodsPayment.CurrentRow.DataBoundItem as PaidPeriod;
            }

            if (licParam == null || pay == null)
                return;

            var form = new DistributionForm(pay, licParam, period);

            if (form.ShowDialog() == DialogResult.OK)
            {
                var linkList = new List<MoneyPeriodLink>();
                foreach (var item in licParam.Lic.PaidPeriod)
                {
                    var itemList = item.MoneyPeriodLink;
                    linkList.AddRange(itemList);
                }

                var service = CalculationBRService.GetInstance();

                var retList = service.SaveLink(CustId, linkList);
                if (retList != null)
                {
                    var dic = retList.ToDictionary(rec => new {rec.PeriodId, rec.PaidId});
                    linkList.ForEach(dest =>
                    {
                        var sors = dic[new {dest.PeriodId, dest.PaidId}];
                        dest.SetFields(sors);
                        dest.Paid.SetFields(sors.Paid);
                    });
                }

                foreach (var item in linkList)
                {
                    var payCustomer = MoneyReceivedList.SingleOrDefault(rec => rec.PaidId == item.PaidId);
                    if (payCustomer != null)
                        payCustomer.DestribAmount = item.Paid.DestribAmount;
                }
                SetupAllBinding();
                RefreshData();
            }
        }

        private void RefreshData()
        {
            gvPeriodsPayment.MasterTemplate.Refresh();
            gvLicenseAgr.MasterTemplate.Refresh();
            gvUserMoneys.MasterTemplate.Refresh();
        }

        /// <summary>
        /// Закрити період
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClosePeriod_Click(object sender, EventArgs e)
        {
            if (!(gvPeriodsPayment.CurrentRow?.DataBoundItem is PaidPeriod period))
                return;

            if (MessageBox.Show($"Закрити період {period.PeriodName} ?", "Закриття періоду", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                period.Status = 7;
                var service = CalculationBRService.GetInstance();
                var result = service.ChangePeriodStatus(period);
                // todo: hande result
                bsPaidPeriod.RemoveCurrent();
                RefreshData();
            }
        }

        private void GvPeriodsPayment_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            buttonController.ChangePeriod(e.CurrentRow?.DataBoundItem as PaidPeriod);
        }

        // оновити дані
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _stateRecorder.RecordState();
            UpdateData?.Invoke();
            _stateRecorder.RestoreState();
        }

        /// <summary>
        /// Прив'язати суму до авансу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAttachPrepayOrLumpSum_Click(object sender, EventArgs e)
        {
            if (!(gvPrepays.CurrentRow?.DataBoundItem is FT_TSK_1_BRMoneyPrepay moneyPrepay))
                return;

            if (!(gvUserMoneys.CurrentRow.DataBoundItem is MoneyReceived moneyReceived))
                return;
            
            var prepaysLinkForm = new PrepaysLinkForm(moneyReceived, moneyPrepay);
            prepaysLinkForm.ShowDialog();
        }

        private async void gvPrepays_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var isTurn = (bool)e.Row.Cells["IsTurnAmount"].Value;
            if (isTurn)
                return;

            var confirmAction = MessageShow.ConfirmAction("Виконати зарахування виплат?");
            if(confirmAction != DialogResult.Yes)
                return;

            var item = (FT_TSK_1_BRMoneyPrepay) e.Row.DataBoundItem;

            // сума прив'язки повинна співпадати з сумою виплати
            bool isInvalid = !item.LinkAmount.HasValue || item.LinkAmount.Value == 0m || 
                             !item.PrepaySum.HasValue || item.PrepaySum.Value == 0m ||
                             item.LinkAmount.Value != item.PrepaySum.Value;

            if (isInvalid)
            {
                MessageShow.ShowWarning("Прив'язана сума повинна бути рівна сумі виплати в грн!");
                return;
            }

            // запускати проводку можна якщо її ще не було
            if ((item.TurnAmount ?? 0m) != 0m)
                return;

            var service = CalculationBRService.GetInstance();
            var result = await service.PayPrepaymentAsync(item.LicId.Value, item.CustIdRH.Value);
            if (result.IsSuccess)
            {
                MessageShow.ShowInfo("Зарахування виплати виконано!");
            }
            else
            {
                if (result.HasException)
                    ShowMessage.ShowError(result.Exception);
                else
                    ShowMessage.ShowError($"Неможливо виконати зарахування виплати! Status Code: {result.StatusCode}");
            }

            _stateRecorder.RecordState();
            UpdateData?.Invoke();
            _stateRecorder.RestoreState();
        }
    }

    class ButtonController
    {
        private readonly RadButton _btnNewPeriod;
        private readonly RadMenuItem _btnDistribute;
        private readonly RadButton _btnClosePeriod;

        public ButtonController(RadButton btnNewPeriod, RadMenuItem btnDistribute, RadButton btnClosePeriod)
        {
            _btnNewPeriod = btnNewPeriod;
            _btnDistribute = btnDistribute;
            _btnClosePeriod = btnClosePeriod;
        }

        public void ChangePeriod(PaidPeriod period)
        {
            if (period == null || period.Amount > period.Distribamount + period.Undistribamount)
                _btnClosePeriod.Enabled = false;
            else
                _btnClosePeriod.Enabled = true;
        }
    }
}
