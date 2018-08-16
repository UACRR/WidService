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

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetReqRef : UserControl
    {
        public event WorkRhSaveEventHandler OnWorkRhSave;
        public event ChangeLicenseTypeEventHandler OnLicenseTypeChange;
        public event SaveCustomerEventHandler OnLicenseSaveNeed;
        public event LisenseStatusChangeEventHandler OnLicenseCloseAndDelete;

        private Customer _customer;
        private ConsumerBigRightView _bigRightView;
        private AnketaDictionaties _dictionaties;
        private IList<BigRightRequestBidAuthors> _authors;
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
        }

        public void SetAnketaDictionary(AnketaDictionaties dictionaties)
        {
            _dictionaties = dictionaties;
            bsDictionary.DataSource = _dictionaties.workType;
        }

        /// <summary>
        /// Дані для контрола
        /// </summary>
        /// <param name="comsumerBigRightView"></param>
        public void SetAndUpdateData(Customer customer, ConsumerBigRightView bigRightView, IList<BigRightRequests> listRequests, IList<BigRightRequestBidAuthors> author)
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
                    btnToReference.Visible = true;
                    btnCreate.Text = "Нова заявка";
                    btnDelete.Text = "Вилучити заявку";
                }
                    break;
                case ControlRequestOrReferenceType.Reference:
                {
                    btnToReference.Visible = false;
                    btnCreate.Text = "Створити ліцензію";
                    btnDelete.Text = "Вилучити довідку";
                }
                    break;
            }
        }

        //клік на гріду по кнопкі редагувати
        private void gvViewRequests_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Row.DataBoundItem is BigRightRequests item)
            {
                if ((_typeControl == ControlRequestOrReferenceType.Request) && (2 <= item.LicStatus && item.LicStatus <= 4)) return;
                if ((_typeControl == ControlRequestOrReferenceType.Reference) && (item.LicStatus == 3 || item.LicStatus == 4)) return;
                bool resetStatus = (_typeControl == ControlRequestOrReferenceType.Request && item.LicStatus == 5)
                                 ||(_typeControl == ControlRequestOrReferenceType.Reference && (item.LicStatus == 2 || item.LicStatus == 5));

                RequestForm requestForm = new RequestForm(_customer, _bigRightView, _dictionaties, FormType.Edit, item.LicId);
                if (requestForm.ShowDialog() == DialogResult.OK)
                {
                    if (OnLicenseSaveNeed?.Invoke(_customer) ?? false)
                    {
                        if(resetStatus)
                            OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 0, false);
                        MessageBox.Show("Зміни збережено!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Не можливо зберегти зміни!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //зміна рядка на грід
        private void gvViewRequests_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            //нема в наявності записів заявоч чи довідок (залежно від типу ctrl)
            if(e?.CurrentRow == null || gvViewRequests.RowCount == 0)
            {
                bindingSource1.DataSource = typeof(BigRightRequestBidAuthors);
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnToReference.Enabled = false;
                //створити заявку
                btnCreate.Enabled = _typeControl != ControlRequestOrReferenceType.Reference;
            }
            else
            {
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }

            var item = e?.CurrentRow?.DataBoundItem as BigRightRequests;
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
            btnToAccept.Enabled = item?.LicStatus == 0 || item?.LicStatus == 1;
            // видалити
            btnDelete.Enabled = _typeControl == ControlRequestOrReferenceType.Request && item?.LicStatus == 0;
            // (видима в заявках) в стан довідки при статусі активна або на погодження
            btnToReference.Enabled = item?.LicStatus <= 3;
            // створити ліцензію
            btnCreate.Enabled = item?.LicStatus == 2;

            bindingSource1.DataSource = _authors.Where(rec => rec.LicId == item?.LicId).ToList();

        }

        private void SetBtnFunc(ButtonFunctionType type)
        {
            _functionType = type;
            if(type != ButtonFunctionType.None)
                btnToAccept.Text = _btnDictionary[type];
        }

        private void MiddleControlCabinetReqRef_Leave(object sender, EventArgs e)
        {
            if (gvViewRequests?.CurrentRow?.DataBoundItem is BigRightRequests item)
                CallSaveRequest(item.LicId);
        }

        #region FILTERING (пошук)

        private void gvViewRequests_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvViewRequests.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvViewRequests.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }

                gvViewRequests.EndUpdate(false);
                return;
            }

            //фільтр не пустий
            gvViewRequests.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvViewRequests.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearch.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    e.Visible = true;
                    e.Row.Cells[i].Style.CustomizeFill = true;
                    e.Row.Cells[i].Style.DrawFill = true;
                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                }
                else
                {
                    e.Row.Cells[i].Style.Reset();
                }

                gvViewRequests.EndUpdate(false);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvViewRequests.MasterTemplate.Refresh();
        }

        #endregion

        private List<WorkRh> _workRhList = new List<WorkRh>();
        private void gvCreativeRole_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            
            if (e?.Row?.DataBoundItem is BigRightRequestBidAuthors item/* && _typeControl == ControlRequestOrReferenceType.Request*/)
            {
                _saveNeedStatus = SaveNeedStatus.Yes;
                var obj = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec.LicId == item.LicId)?.LicenseBigR?.Obj;
                var copyRight = obj?.CopyRight?.SingleOrDefault(rec => rec.CRightId == item.CRightId);
                var workRh = copyRight?.WorkRh;
                if(workRh != null)
                {
                    workRh.WorkTypeCl = item?.WorkRh?.WorkTypeCl;
                    workRh.WorkCoommentCl = _dictionaties.workType.SingleOrDefault(rec=>rec.CodeI == item.WorkRh.WorkTypeCl)?.Name;
                }

                if (_workRhList.Contains(workRh))
                {
                    _workRhList.Remove(workRh);
                    _workRhList.Add(workRh);
                }
                else
                    _workRhList.Add(workRh);
                

            }
        }

        private void gvCreativeRole_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
        {
            if (_workRhs == null /*&& _typeControl == ControlRequestOrReferenceType.Request*/ && e?.Row?.DataBoundItem is BigRightRequestBidAuthors item)
            {
                var obj = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec.LicId == item.LicId)?.LicenseBigR?.Obj;
                var copyRight = obj?.CopyRight?.SingleOrDefault(rec => rec.CRightId == item.CRightId);

                if (obj != null)
                    foreach (var right in obj.CopyRight) // заліпить null id
                    {
                        if (right.WorkRh == null)
                            right.WorkRh = new WorkRh();
                        right.WorkRh.CRightId = right.CRightId;
                        //_authors.SingleOrDefault(rec=>rec.LicId == item.LicId)?.WorkTypeCl
                    }

                if (_workRhs == null && obj != null) //зберегти поточний стан об'єктів
                    Serialization(obj.CopyRight);
            }
            else if (_typeControl == ControlRequestOrReferenceType.Reference)
            {

            }
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
                    if (gvViewRequests.CurrentRow.DataBoundItem is BigRightRequests item)
                    {
                        if (OnLicenseTypeChange?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), ConsumerService.LicType.License) ?? false)
                            ExtensionUtils.ShowInfoMessage("Довідка переведена в Ліцензію", "Успішно", MessageBoxIcon.Information);
                        else
                            ExtensionUtils.ShowInfoMessage("Не можливо створити ліцензію з довідки", "Помилка", MessageBoxIcon.Error);
                    }
                }break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_typeControl == ControlRequestOrReferenceType.Request)
            {
                if (gvViewRequests?.CurrentRow?.DataBoundItem is BigRightRequests item)
                    CallSaveRequest(item.LicId, true);
            }
            else if (_typeControl == ControlRequestOrReferenceType.Reference)
            {
                //some code
                if (gvViewRequests?.CurrentRow?.DataBoundItem is BigRightRequests item)
                    CallSaveRequest(item.LicId, true);
                //copypast ^ ^ ^
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_typeControl == ControlRequestOrReferenceType.Request)
            {
                _saveNeedStatus = SaveNeedStatus.No;
                Deserialization();
            }
            else if (_typeControl == ControlRequestOrReferenceType.Reference)
            {
                //some code
            }
        }

        #region save state obj

        private List<WorkRh> _workRhs;
        private ObservableListSource<CopyRight> _copyRightReferense;
        private IList<BigRightRequestBidAuthors> _authorsTempSerialize;
        private void Serialization(ObservableListSource<CopyRight> copyRight)
        {
            _authorsTempSerialize = new List<BigRightRequestBidAuthors>();
            foreach (var author in _authors)
            {
                var item = new BigRightRequestBidAuthors();
                item.SetFields(author);
                item.WorkRh = new WorkRh();
                item.WorkRh.SetFields(author.WorkRh);
                _authorsTempSerialize.Add(item);
            }

            _copyRightReferense = copyRight;
            _workRhs = new List<WorkRh>();
            foreach (var item in copyRight)
            {
                var workRh = new WorkRh();
                workRh.SetFields(item.WorkRh);
                _workRhs.Add(workRh);
            }
        }
        private void Deserialization()
        {
            _workRhList.Clear();
            var source = gvViewRequests.CurrentRow.DataBoundItem as BigRightRequests;

            foreach (var item in _workRhs)
                _copyRightReferense?.SingleOrDefault(rec => rec.CRightId == item.CRightId)?.WorkRh.SetFields(item);

            _workRhs = null;

            //оновити грід
            bindingSource1.DataSource = typeof(BigRightRequestBidAuthors);
            _authors.Clear();
            foreach (var authors in _authorsTempSerialize)
                _authors.Add(authors);

            _authorsTempSerialize = null;
            bindingSource1.DataSource = _authors.Where(rec => rec.LicId == source?.LicId).ToList();
            gvCreativeRole.MasterTemplate.Refresh();
        }

        #endregion

        //повідомлення про не збережені зміни
        private void CallSaveRequest(int idRow, bool isBtnSave = false)
        {
            if (_saveNeedStatus == SaveNeedStatus.Yes)
                if (isBtnSave || RadMessageBox.Show("Зберегти внесені зміни?", "Внесені зміни не були збережені!", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (OnWorkRhSave?.Invoke(idRow, _workRhList) ?? false)
                        MessageBox.Show("Зміни успішно збережено!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        MessageBox.Show("Помилка збереження!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    _workRhs = null;
                    _workRhList.Clear();
                }
                else
                {
                    Deserialization();
                }

            _saveNeedStatus = SaveNeedStatus.No;
        }

        private void btnToReference_Click(object sender, EventArgs e)
        {
            if (gvViewRequests.CurrentRow.DataBoundItem is BigRightRequests item)
            {
                if(OnLicenseTypeChange?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec=>rec.LicId == item.LicId), ConsumerService.LicType.Reference) ?? false)
                    ExtensionUtils.ShowInfoMessage("Заявка переведена в довідку", "Успішно", MessageBoxIcon.Information);
                else
                    ExtensionUtils.ShowInfoMessage("Не можливо створити довідку з заявки", "Помилка",MessageBoxIcon.Error);
            }
        }



        private void gvViewRequests_CurrentRowChanging(object sender, Telerik.WinControls.UI.CurrentRowChangingEventArgs e)
        {
            if (_saveNeedStatus == SaveNeedStatus.Yes && e?.CurrentRow?.DataBoundItem is BigRightRequests item)
                CallSaveRequest(item.LicId);
        }

        private void btnToAccept_Click(object sender, EventArgs e)
        {
            if (gvViewRequests?.CurrentRow?.DataBoundItem is BigRightRequests item)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvViewRequests?.CurrentRow?.DataBoundItem is BigRightRequests item)
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
