using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using Microsoft.Office.Interop.Excel;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetReqRef : UserControl
    {
        private const string SuccessRequestAdd = "Нову завявку додано!";
        private const string ErrorRequestAdd = "Неможливо зберегти нову заявку!";

        public event ChangeLicenseTypeEventHandler OnLicenseTypeChange;
        public event SaveCustomerEventHandler OnLicenseSaveNeed;
        public event LisenseStatusChangeEventHandler OnLicenseCloseAndDelete;
        public event EmptyEventHandler UpdateData;

        private Customer _customer;
        private MainGridConsumerBigRightView _bigRightView;
        private AnketaDictionaties _dictionaties;
        private IList<AuthorsForLicenseBigRightView> _authors;
        private ControlRequestOrReferenceType _typeControl = ControlRequestOrReferenceType.None;
        private Dictionary<ButtonFunctionType, string> _btnDictionary = new Dictionary<ButtonFunctionType, string>{
            {ButtonFunctionType.Accept, "Акцептувати"},
            {ButtonFunctionType.Agree, "На погодження"},
            {ButtonFunctionType.None, string.Empty}
        };

        private ButtonFunctionType _functionType = ButtonFunctionType.None;

        public MiddleControlCabinetReqRef()
        {
            InitializeComponent();
            splitContainer.PanelCollapsing += SplitContainer_PanelCollapsing;
            ctrlSearch.SetUsageGrid(gvViewRequests);
        }

        private void MiddleControlCabinetReqRef_Load(object sender, EventArgs e)
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
            RadButtonElement btn = sender as RadButtonElement;
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

        public void SetAnketaDictionary(AnketaDictionaties anketaDictionaties)
        {
            _dictionaties = anketaDictionaties;
            bsDictionary.DataSource = _dictionaties.workType;
        }

        /// <summary>
        /// Дані для контрола
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="bigRightView"></param>
        /// <param name="listRequests"></param>
        /// <param name="author"></param>
        public void SetAndUpdateData(Customer customer, MainGridConsumerBigRightView bigRightView, IList<RequestsOrReferenceBigRightView> listRequests, IList<AuthorsForLicenseBigRightView> author)
        {
            _customer = customer;
            _authors = author;
            _bigRightView = bigRightView;
            
            ctrlAgrInfo.DataSource = _bigRightView;
            gvViewRequests.DataSource = listRequests;
            
            // gvCreativeRole.DataSource = author;
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

        private void SetTypeControl(ControlRequestOrReferenceType type)
        {
            switch (type)
            {
                case ControlRequestOrReferenceType.None:
                    break;
                case ControlRequestOrReferenceType.Request:
                {
                    btnChangeToLicense.Visibility = ElementVisibility.Collapsed;
                    btnCreate.Text = "Нова заявка";
                }
                    break;
                case ControlRequestOrReferenceType.Reference:
                {
                    btnChangeToReference.Visibility = ElementVisibility.Collapsed;
                    btnCreate.Text = "Створити ліцензію";
                }
                    break;
            }
        }

        //клік по кнопках на гріду
        private void gvViewRequests_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Row.DataBoundItem is RequestsOrReferenceBigRightView item && item.LicStatus != 4)
                switch (e.Column.FieldName)
                {
                    case "editBtn":
                    {
                        switch (_typeControl)
                        {
                            case ControlRequestOrReferenceType.Request:
                            {
                                if (!(2 <= item.LicStatus && item.LicStatus <= 3)) // статуси 0, 1, 5 - редагування
                                    CallRequestForm(FormType.Edit, item);
                                else                                               //перегляд
                                    CallRequestForm(FormType.View, item);
                            }
                                break;

                            case ControlRequestOrReferenceType.Reference:
                            {
                                CallRequestForm(item.LicStatus != 3 ? FormType.Edit : FormType.View, item);
                            }
                                break;
                        }
                    }
                        break;
                    case "deleteBtn":
                        if(_typeControl == ControlRequestOrReferenceType.Request && item.LicStatus == 0)
                            DeleteLicense();
                        break;
                }
        }

        private void CallRequestForm(FormType type, RequestsOrReferenceBigRightView item)
        {
            var requestForm = new RequestForm(_customer, _bigRightView, type, item.LicId, windowType: _typeControl) { StartPosition = FormStartPosition.CenterParent };

            if (requestForm.ShowDialog() == DialogResult.OK && type == FormType.Edit)
            {
                var result = OnLicenseSaveNeed?.Invoke(_customer) ?? false;
                if (result)
                {
                    OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 0, false);
                    UpdateData?.Invoke();
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
                if (item?.LicStatus is 0)
                    SetBtnFunc(ButtonFunctionType.Agree);
                else if (item?.LicStatus is 1)
                    SetBtnFunc(ButtonFunctionType.Accept);
                else
                    SetBtnFunc(ButtonFunctionType.None);
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

        private void SetBtnFunc(ButtonFunctionType type)
        {
            _functionType = type;
            if(type != ButtonFunctionType.None)
                btnStatusAccept.Text = _btnDictionary[type];
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            switch (_typeControl)
            {
                case ControlRequestOrReferenceType.None:
                    break;
                case ControlRequestOrReferenceType.Request:
                {
                    var requestForm = new RequestForm(_customer, _bigRightView);
                    if(requestForm.ShowDialog() == DialogResult.OK)
                    {
                        var result = OnLicenseSaveNeed?.Invoke(_customer) ?? false;
                        if (result)
                            UpdateData?.Invoke();
                        MessageShow.ShowInfoByResult(SuccessRequestAdd, ErrorRequestAdd,result);
                    }
                }break;

                case ControlRequestOrReferenceType.Reference:
                {

                }break;
            }
        }

        private void btnToAccept_Click(object sender, EventArgs e)
        {
            if (gvViewRequests?.CurrentRow?.DataBoundItem is RequestsOrReferenceBigRightView item)
            {
                bool result = false;
                switch (_functionType)
                {
                    case ButtonFunctionType.None:
                        break;
                    case ButtonFunctionType.Accept:
                    {
                        result = OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 0, false) ?? false;
                        if(result)
                            ExtensionUtils.ShowInfoMessage("Акцептовано!", "Успішно", MessageBoxIcon.Information);
                        else
                            ExtensionUtils.ShowInfoMessage("Не можливо акцептувати", "Помилка!", MessageBoxIcon.Error);
                    }
                        break;
                    case ButtonFunctionType.Agree:
                    {
                        result = OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 3, false) ?? false;
                        if(result)
                            ExtensionUtils.ShowInfoMessage("Відправлено на погодження!", "Успішно", MessageBoxIcon.Information);
                        else
                            ExtensionUtils.ShowInfoMessage("Не можливо відправити на погодження", "Помилка!", MessageBoxIcon.Error);
                    }
                        break;
                }
                if(result)
                    UpdateData?.Invoke();
            }
        }

        private void DeleteLicense()
        {
            if (gvViewRequests?.CurrentRow?.DataBoundItem is RequestsOrReferenceBigRightView item)
            {
                string reqref = _typeControl == ControlRequestOrReferenceType.Request ? "Заявк" :
                                _typeControl == ControlRequestOrReferenceType.Reference ? "Довідк" : string.Empty;

                string reqrefl = _typeControl == ControlRequestOrReferenceType.Request ? "заявку!" :
                    _typeControl == ControlRequestOrReferenceType.Reference ? "довідку!" : string.Empty;

                if (MessageBox.Show(reqref + "а буде закрита та автоматично видалена. Підтвердити дію?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec=> rec.LicId == item.LicId),item.LicVersion, 10, false) ?? false)
                    {
                        ExtensionUtils.ShowInfoMessage(reqref + "у закрито!", "Успішно", MessageBoxIcon.Information);
                        UpdateData?.Invoke();
                    }
                    else
                        ExtensionUtils.ShowInfoMessage("Не можливо закрити " + reqrefl, "Помилка", MessageBoxIcon.Error);
                }
            }
        }

        private void btnChangeToReference_Click(object sender, EventArgs e)
        {
            if (gvViewRequests.CurrentRow.DataBoundItem is RequestsOrReferenceBigRightView item)
            {
                if (OnLicenseTypeChange?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), ConsumerService.LicType.Reference) ?? false)
                {
                    ExtensionUtils.ShowInfoMessage("Заявка переведена в довідку", "Успішно", MessageBoxIcon.Information);
                    UpdateData?.Invoke();
                }
                else
                    ExtensionUtils.ShowInfoMessage("Не можливо створити довідку з заявки", "Помилка", MessageBoxIcon.Error);
            }
        }

        private void btnChangeToLicense_Click(object sender, EventArgs e)
        {
            if (gvViewRequests.CurrentRow.DataBoundItem is RequestsOrReferenceBigRightView item)
            {
                if (OnLicenseTypeChange?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), ConsumerService.LicType.License) ?? false)
                {
                    ExtensionUtils.ShowInfoMessage("Довідка переведена в Ліцензію", "Успішно", MessageBoxIcon.Information);
                    UpdateData?.Invoke();
                }
                else
                    ExtensionUtils.ShowInfoMessage("Не можливо створити ліцензію з довідки", "Помилка", MessageBoxIcon.Error);
            }
        }

        // оновлення даних
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData?.Invoke();
        }
    }

    public enum SaveNeedStatus
    {
        Yes,
        No
    }

    public enum ButtonFunctionType
    {
        None,
        /// <summary>
        /// Акцептувати
        /// </summary>
        Accept,
        /// <summary>
        /// На погодження
        /// </summary>
        Agree
    }
}
