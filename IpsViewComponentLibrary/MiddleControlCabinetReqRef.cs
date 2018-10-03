using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ipsFormsDesign;
using ipsFormsDesign.Services;
using Microsoft.Office.Interop.Excel;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetReqRef : UserControl
    {
        public event WorkRhSaveEventHandler OnWorkRhSave;
        public event ChangeLicenseTypeEventHandler OnLicenseTypeChange;
        public event SaveCustomerEventHandler OnLicenseSaveNeed;
        public event LisenseStatusChangeEventHandler OnLicenseCloseAndDelete;

        private Customer _customer;
        private MainGridConsumerBigRightView _bigRightView;
        private AnketaDictionaties _dictionaties;
        private IList<AuthorsForLicenseBigRightView> _authors;
        private ControlRequestOrReferenceType _typeControl = ControlRequestOrReferenceType.None;
        private SaveNeedStatus _saveNeedStatus = SaveNeedStatus.No;
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
        /// <param name="comsumerBigRightView"></param>
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

        //клік на гріду по кнопках
        private void gvViewRequests_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
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
                        if(_typeControl == ControlRequestOrReferenceType.Request && item?.LicStatus == 0)
                            DeleteLicense();
                        break;
                }
        }

        private void CallRequestForm(FormType type, RequestsOrReferenceBigRightView item)
        {
            RequestForm requestForm = new RequestForm(_customer, _bigRightView, _dictionaties, type, item.LicId) { StartPosition = FormStartPosition.CenterParent };

            if (requestForm.ShowDialog() == DialogResult.OK && type == FormType.Edit)
            {
                if (OnLicenseSaveNeed?.Invoke(_customer) ?? false)
                {
                    OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 0, false);
                    MessageBox.Show("Зміни збережено!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Не можливо зберегти зміни!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //зміна рядка на грід
        private void gvViewRequests_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
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
                    RequestForm requestForm = new RequestForm(_customer, _bigRightView, _dictionaties);
                    if(requestForm.ShowDialog() == DialogResult.OK)
                    {
                        if (OnLicenseSaveNeed?.Invoke(_customer) ?? false)
                            MessageBox.Show("Нову завявку додано!", "Збережено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Не можливо зберегти нову заявку!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                switch (_functionType)
                {
                    case ButtonFunctionType.None:
                        break;
                    case ButtonFunctionType.Accept:
                    {
                        if (OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 0, false) ?? false)
                            ExtensionUtils.ShowInfoMessage("Акцептовано!", "Успішно", MessageBoxIcon.Information);
                        else
                            ExtensionUtils.ShowInfoMessage("Не можливо акцептувати", "Помилка!", MessageBoxIcon.Error);
                    }
                        break;
                    case ButtonFunctionType.Agree:
                    {
                        if (OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 3, false) ?? false)
                            ExtensionUtils.ShowInfoMessage("Відправлено на погодження!", "Успішно", MessageBoxIcon.Information);
                        else
                            ExtensionUtils.ShowInfoMessage("Не можливо відправити на погодження", "Помилка!", MessageBoxIcon.Error);
                    }
                        break;
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
                    if (OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec=> rec.LicId == item.LicId),item.LicVersion,4, false) ?? false)
                        ExtensionUtils.ShowInfoMessage(reqref + "у закрито!", "Успішно", MessageBoxIcon.Information);
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
                    ExtensionUtils.ShowInfoMessage("Заявка переведена в довідку", "Успішно", MessageBoxIcon.Information);
                else
                    ExtensionUtils.ShowInfoMessage("Не можливо створити довідку з заявки", "Помилка", MessageBoxIcon.Error);
            }
        }

        private void btnChangeToLicense_Click(object sender, EventArgs e)
        {
            if (gvViewRequests.CurrentRow.DataBoundItem is RequestsOrReferenceBigRightView item)
            {
                if (OnLicenseTypeChange?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), ConsumerService.LicType.License) ?? false)
                    ExtensionUtils.ShowInfoMessage("Довідка переведена в Ліцензію", "Успішно", MessageBoxIcon.Information);
                else
                    ExtensionUtils.ShowInfoMessage("Не можливо створити ліцензію з довідки", "Помилка", MessageBoxIcon.Error);
            }
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
