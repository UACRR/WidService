using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.Shared.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight.Cabinet
{
    public partial class RequestReferenceControl : UserControl
    {
        private const string SuccessRequestAdd = "Нову завявку додано!";
        private const string ErrorRequestAdd = "Неможливо зберегти нову заявку!";
        private const string ChangeToReferenceSuccess = "Заявка переведена в довідку!";
        private const string ChangeToReferenceError = "Неможливо перевести заявку в довідку!";
        private const string ChangeToLicenseSuccess = "Довідка переведена в ліцензію!";
        private const string ChangeToLicenseError = "Неможливо перевести довідку в ліцензію!";

        private const string AcceptSuccess = "Акцептовано!";
        private const string AcceptError = "Неможливо акцептувати!";
        private const string SendConfirmationSuccess = "Відправлено на погодження!";
        private const string SendConfirmationError = "Неможливо відправити на погодження!";

        private const string RequestDeleteQuestion = "Заявка буде закрита та автоматично видалена. Підтвердити дію?";
        private const string ReferenceDeleteQuestion = "Довідка буде закрита та автоматично видалена. Підтвердити дію?";
        private const string RequestDeleteSuccess = "Заявку закрито!";
        private const string RequestDeleteError = "Неможливо закрити заявку!";
        private const string ReferenceDeleteSuccess = "Довідку закрито!";
        private const string ReferenceDeleteError = "Неможливо закрити довідку!";

        private const string BtnTextNewRequest = "Нова заявка";
        private const string BtnTextCreateLicense = "Створити ліцензію";

        public event ChangeLicenseTypeEventHandler OnLicenseTypeChange;
        public event SaveCustomerEventHandler OnLicenseSaveNeed;
        public event LicenseStatusChangeEventHandler OnLicenseStatusChange;
        public event EmptyEventHandler UpdateData;

        private readonly GridStateRecorder _gridStateRecorder = new GridStateRecorder();

        private Customer _customer;
        private IList<AuthorsForLicenseBigRightView> _authors;
        private ControlRequestOrReferenceType _typeControl = ControlRequestOrReferenceType.None;
        private BRLicenseButtonActionType _functionType = BRLicenseButtonActionType.None;

        private readonly Dictionary<BRLicenseButtonActionType, string> _btnDictionary = new Dictionary<BRLicenseButtonActionType, string>{
            {BRLicenseButtonActionType.Accept, "Акцептувати"},
            {BRLicenseButtonActionType.Confirm, "На погодження"},
            {BRLicenseButtonActionType.None, string.Empty}
        };


        public RequestReferenceControl()
        {
            InitializeComponent();
            if (IpsGlobal.AnketaDictionaties != null)
                bsDictionaryWorkType.DataSource = IpsGlobal.AnketaDictionaties.workType;

            splitContainer.PanelCollapsing += SplitContainer_PanelCollapsing;
            ctrlSearch.SetUsageGrid(gvViewRequests);
            _gridStateRecorder.AddGrid(gvViewRequests);
        }

        /// <summary>
        /// Дані для контрола
        /// </summary>
        /// <param name="customer"></param>
        public void SetAndUpdateData(Customer customer)
        {
            _customer = customer;
            _authors = ViewsSingleton.AuthorsForLicenseBigRightView;
            ctrlAgrInfo.DataSource = ViewsSingleton.ConsumerBigRightView;
            if (_typeControl == ControlRequestOrReferenceType.Request)
                gvViewRequests.DataSource = ViewsSingleton.RequestsBigRightView;
            else if (_typeControl == ControlRequestOrReferenceType.Reference)
                gvViewRequests.DataSource = ViewsSingleton.ReferenceBigRightView;
        }

        #region * * * PROPERTIES * * *

        private string QuestionDeleteMsg
        {
            get
            {
                switch (_typeControl)
                {
                    case ControlRequestOrReferenceType.Request:
                        return RequestDeleteQuestion;
                    case ControlRequestOrReferenceType.Reference:
                        return ReferenceDeleteQuestion;
                    default:
                        return string.Empty;
                }
            }
        }

        private string ResultSuccessMsg
        {
            get
            {
                switch (_typeControl)
                {
                    case ControlRequestOrReferenceType.Request:
                        return RequestDeleteSuccess;
                    case ControlRequestOrReferenceType.Reference:
                        return ReferenceDeleteSuccess;
                    default:
                        return string.Empty;
                }
            }
        }

        private string ResultErrorMsg
        {
            get
            {
                switch (_typeControl)
                {
                    case ControlRequestOrReferenceType.Request:
                        return RequestDeleteError;
                    case ControlRequestOrReferenceType.Reference:
                        return ReferenceDeleteError;
                    default:
                        return string.Empty;
                }
            }
        }

        public ControlRequestOrReferenceType TypeControl
        {
            get => _typeControl;
            set
            {
                _typeControl = value;
                SetTypeControl(value);
            }
        }

        #endregion

        /// <summary>
        /// Змінити тип контрола: заявка || довідка
        /// </summary>
        /// <param name="type">Тип контролу</param>
        private void SetTypeControl(ControlRequestOrReferenceType type)
        {
            switch (type)
            {
                case ControlRequestOrReferenceType.Request:
                    btnChangeToLicense.Visibility = ElementVisibility.Collapsed;
                    btnCreate.Text = BtnTextNewRequest;
                    break;

                case ControlRequestOrReferenceType.Reference:
                    btnChangeToReference.Visibility = ElementVisibility.Collapsed;
                    btnCreate.Text = BtnTextCreateLicense;
                    break;
            }
        }

        private void RequestReferenceControl_Load(object sender, EventArgs e)
        {
            splitContainer.Splitters.First().NextNavigationButton.PropertyChanged += NextNavigationButton_PropertyChanged;
            splitContainer.Splitters.First().NextNavigationButton.Visibility = ElementVisibility.Collapsed;
            splitContainer.Splitters.First().PrevNavigationButton.PropertyChanged += NextNavigationButton_PropertyChanged;
            splitContainer.Splitters.First().PrevNavigationButton.Visibility = ElementVisibility.Visible;
        }

        private void SplitContainer_PanelCollapsing(object sender, RadSplitContainer.PanelCollapsingEventArgs e)
        {
            var splitter = splitContainer.Splitters.First();
            splitter.PrevNavigationButton.AngleTransform = 180f;
        }

        private void NextNavigationButton_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var btn = sender as RadButtonElement;
            if (e.PropertyName == "Visibility" && btn?.Class == "PrevDownSplitterThumb")
            {
                if (btn.Visibility == ElementVisibility.Collapsed)
                {
                    btn.Visibility = ElementVisibility.Visible;
                    btn.AngleTransform = 0f;
                }
            }

            if (e.PropertyName == "Visibility" && btn?.Visibility == ElementVisibility.Visible && btn.Class == "NextUpSplitterThumb")
            {
                btn.Visibility = ElementVisibility.Collapsed;
            }
        }

        //клік по кнопках на гріду
        private void gvViewRequests_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (!(e.Row.DataBoundItem is RequestsOrReferenceBigRightView item) || item.LicStatus == 4 || item.LicStatus == 10)
                return;

            switch (e.Column.FieldName)
            {
                case "editBtn":
                    switch (_typeControl)
                    {
                        case ControlRequestOrReferenceType.Request:
                            // статуси 0, 1, 5 - редагування
                            if (2 <= item.LicStatus && item.LicStatus <= 3)
                                CallRequestForm(ScopeOfUseForm.View, item);
                            else
                                CallRequestForm(ScopeOfUseForm.Edit, item);

                            break;

                        case ControlRequestOrReferenceType.Reference:
                            CallRequestForm(item.LicStatus != 3 ? ScopeOfUseForm.Edit : ScopeOfUseForm.View, item);
                            break;
                    }
                    
                    break;
                case "deleteBtn":
                    if(_typeControl == ControlRequestOrReferenceType.Request && item.LicStatus == 0)
                        DeleteLicense();
                    break;
            }
        }

        /// <summary>
        /// Показати форму заявки
        /// </summary>
        /// <param name="type"></param>
        /// <param name="item"></param>
        private void CallRequestForm(ScopeOfUseForm type, RequestsOrReferenceBigRightView item)
        {
            var requestForm = new RequestForm(_customer, ViewsSingleton.ConsumerBigRightView, type, item.LicId, windowType: _typeControl);

            if (requestForm.ShowDialog() == DialogResult.OK && type == ScopeOfUseForm.Edit)
            {
                var result = OnLicenseSaveNeed?.Invoke(_customer) ?? false;
                if (result)
                {
                    OnLicenseStatusChange?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 0, false);
                    RefreshData();
                }
                MessageShow.ShowInfoAfterChanges(result);
            }
        }

        //зміна рядка на грід
        private void gvViewRequests_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            //нема в наявності записів заявоч чи довідок (залежно від типу ctrl)
            if(e?.CurrentRow == null || gvViewRequests.RowCount == 0)
            {
                bindingSource1.DataSource = typeof(AuthorsForLicenseBigRightView);
                btnChangeToReference.Enabled = false;
                btnChangeToLicense.Enabled = false;
            }

            var item = e?.CurrentRow?.DataBoundItem as RequestsOrReferenceBigRightView;
            if (item?.LicStatus == 0 || item?.LicStatus == 1)
            {
                switch (item.LicStatus)
                {
                    case 0:
                        SetButtonStatusAcceptText(BRLicenseButtonActionType.Confirm);
                        break;
                    case 1:
                        SetButtonStatusAcceptText(BRLicenseButtonActionType.Accept);
                        break;
                    default:
                        SetButtonStatusAcceptText(BRLicenseButtonActionType.None);
                        break;
                }
            }
            // на погодження
            btnStatusAccept.Enabled = item?.LicStatus == 0 || item?.LicStatus == 1;
            // (видима в заявках) в стан довідки при статусі активна або на погодження
            btnChangeToReference.Enabled = item?.LicStatus <= 3;
            // створити ліцензію
            btnChangeToLicense.Enabled = _typeControl == ControlRequestOrReferenceType.Reference && item?.LicStatus == 2;
            //створити заявку
            btnCreate.Visible = _typeControl == ControlRequestOrReferenceType.Request;

            bindingSource1.DataSource = _authors.Where(rec => rec.LicId == item?.LicId).ToList();
        }

        /// <summary>
        /// Змінити найменування кнопки групи "Змінити статус"
        /// </summary>
        /// <param name="type"></param>
        private void SetButtonStatusAcceptText(BRLicenseButtonActionType type)
        {
            _functionType = type;
            if(type != BRLicenseButtonActionType.None)
                btnStatusAccept.Text = _btnDictionary[type];
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (_typeControl == ControlRequestOrReferenceType.Request)
            {
                var requestForm = new RequestForm(_customer, ViewsSingleton.ConsumerBigRightView);
                if (requestForm.ShowDialog() == DialogResult.OK)
                {
                    var result = OnLicenseSaveNeed?.Invoke(_customer) ?? false;
                    if (result)
                        UpdateData?.Invoke();
                    MessageShow.ShowInfoByResult(SuccessRequestAdd, ErrorRequestAdd, result);
                }
            }
        }

        // [на погодження]
        private void btnToAccept_Click(object sender, EventArgs e)
        {
            if (!(gvViewRequests?.CurrentRow?.DataBoundItem is RequestsOrReferenceBigRightView item))
                return;

            bool result = false;
            var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId);
            switch (_functionType)
            {
                case BRLicenseButtonActionType.Accept:
                    result = OnLicenseStatusChange?.Invoke(license, item.LicVersion, 0, false) ?? false;
                    MessageShow.ShowInfoByResult(AcceptSuccess, AcceptError, result);
                    break;
                case BRLicenseButtonActionType.Confirm:
                    result = OnLicenseStatusChange?.Invoke(license, item.LicVersion, 3, false) ?? false;
                    MessageShow.ShowInfoByResult(SendConfirmationSuccess, SendConfirmationError, result);
                    break;
            }
            if(result)
                RefreshData();
        }

        /// <summary>
        /// Видалити заявку/довідку 
        /// </summary>
        private void DeleteLicense()
        {
            if (!(gvViewRequests?.CurrentRow?.DataBoundItem is RequestsOrReferenceBigRightView item))
                return;


            if (MessageShow.ConfirmAction(QuestionDeleteMsg) == DialogResult.Yes)
            {
                var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId);
                var result = OnLicenseStatusChange?.Invoke(license, item.LicVersion, 10, false) ?? false;

                if (result)
                    RefreshData();

                MessageShow.ShowInfoByResult(ResultSuccessMsg, ResultErrorMsg, result);
            }
        }

        // [перевести в довідку]
        private void btnChangeToReference_Click(object sender, EventArgs e)
        {
            if (!(ChangeLicenseType(ConsumerService.LicType.Reference) is bool result))
                return;

            MessageShow.ShowInfoByResult(ChangeToReferenceSuccess, ChangeToReferenceError, result);
        }

        // [перевести в ліцензію]
        private void btnChangeToLicense_Click(object sender, EventArgs e)
        {
            if (!(ChangeLicenseType(ConsumerService.LicType.License) is bool result))
                return;

            MessageShow.ShowInfoByResult(ChangeToLicenseSuccess, ChangeToLicenseError, result);
        }

        /// <summary>
        /// Змінити тип ліцензії
        /// </summary>
        /// <param name="licenseType">Тип ліцензії на який потрібно змінити</param>
        /// <returns>Результат обробки запиту</returns>
        private bool? ChangeLicenseType(ConsumerService.LicType licenseType)
        {
            if (!(gvViewRequests.CurrentRow?.DataBoundItem is RequestsOrReferenceBigRightView item))
                return null;

            var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId);
            var success = OnLicenseTypeChange?.Invoke(license, licenseType) ?? false;
            if (success)
                RefreshData();
            return success;
        }

        // кнопка оновлення даних
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// Оновити дані зі збереженням обраного рядка гріда
        /// </summary>
        private void RefreshData()
        {
            _gridStateRecorder.RecordState();
            UpdateData?.Invoke();
            _gridStateRecorder.RestoreState();
        }
    }
}
