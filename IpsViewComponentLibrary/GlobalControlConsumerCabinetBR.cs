using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class GlobalControlConsumerCabinetBR : UserControl
    {
        private int _rowId;

        private readonly TypeRights Rights = TypeRights.BigRights;
        private AnketaDictionaties _anketaDictionaties;
        private Customer _customer;
        private IList<ConsumerBigRightView> _brData;
        private IList<VbrLicense> _agrData;
        private IList<BigRightMasterGenAgr> _genAgrs;
        private IList<BigRightRequests> _requests;
        private IList<BigRightRequests> _reference;
        private IList<BigRightRequestBidAuthors> _authors;
        private IList<BigRightMoneyUndescrib> _moneyUndescribs;
        private IList<BigRightRegister> _registers;
        private IList<BigRightPayslipsSpectacleView> _payslipsSpectacleViews;

        public delegate void BackToMainGrid(int custId);
        /// <summary>
        /// Виникає при натисканні кнопки [До списку споживачів]
        /// </summary>
        public event BackToMainGrid OnBackToGridNeed;

        public delegate void UpdateData(int id);
        /// <summary>
        /// Виникає при зміні поточного рядка на грід та потребі оновити дані
        /// </summary>
        public event UpdateData OnCustomerUpdateDataNeed;

        public event EventHandler OnAddNewCustomer;

        public delegate void EditCustomer(int id);
        public event EditCustomer OnEditCustomer;

        public event SaveCustomerEventHandler OnSaveCustomer;

        public event MiddleControlCabinetFiles.AddNewDocumentHandler OnAddNewDocument;
        public event MiddleControlCabinetFiles.ViewDocumentHandler OnViewDocument;
        public event MiddleControlCabinetPayslips.GetSpectacleView OnGetSpectacleNeed;
        public event LisenseStatusChangeEventHandler OnLicenseStatusChanging;
        public event WorkRhSaveEventHandler OnWorkRhSaveNeed;
        public event ChangeLicenseTypeEventHandler OnChangeLicenseType;
        public event SavePayslipsEventHandler OnSavePayslip;



        public string FilterString
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public GlobalControlConsumerCabinetBR()
        {
            InitializeComponent();
            ctrlCabinet.OnSaveCustomerNeed += CtrlCabinet_OnSaveCustomerNeed;
            ctrlCabinet.OnAddNewDocument += CtrlCabinet_OnAddNewDocument;
            ctrlCabinet.OnViewDocumentNeed += CtrlCabinet_OnViewDocumentNeed;
            ctrlCabinet.OnGetSpectacleNeed += CtrlCabinet_OnGetSpectacleNeed;
            ctrlCabinet.OnLicenseStatusChanging += CtrlCabinet_OnLicenseStatusChanging;
            ctrlCabinet.OnRequestWorkRhSaveNeed += CtrlCabinet_OnRequestWorkRhSaveNeed;
            ctrlCabinet.OnChangeLicenseType += CtrlCabinet_OnChangeLicenseType;
            ctrlCabinet.OnSavePayslip += CtrlCabinet_OnSavePayslip;

            ctrlCabinet.SetDictionaries(_anketaDictionaties);
        }

        private bool CtrlCabinet_OnSavePayslip(RegisterRatedList list)
        {
            return OnSavePayslip?.Invoke(list) ?? false;
        }

        private bool CtrlCabinet_OnChangeLicenseType(LicenseAgreement agreement, ipsFormsDesign.Services.ConsumerService.LicType licType)
        {
            return OnChangeLicenseType?.Invoke(agreement, licType) ?? false;
        }

        private bool CtrlCabinet_OnRequestWorkRhSaveNeed(int licenseId, List<WorkRh> workRhList)
        {
            return OnWorkRhSaveNeed?.Invoke(licenseId, workRhList) ?? false;
        }

        private bool CtrlCabinet_OnLicenseStatusChanging(LicenseAgreement agr, int version, int status, bool changeVer)
        {
            return OnLicenseStatusChanging?.Invoke(agr, version, status, changeVer) ?? false;
        }

        private IList<BigRightSpectacleView> CtrlCabinet_OnGetSpectacleNeed(int custId)
        {
            return OnGetSpectacleNeed?.Invoke(custId);
        }

        private void CtrlCabinet_OnViewDocumentNeed(int custId, int typeDocument, string fileName)
        {
            OnViewDocument?.Invoke(custId, typeDocument, fileName);
        }

        private void CtrlCabinet_OnAddNewDocument(int custId, int typeDocument, string fileName, string comment)
        {
            OnAddNewDocument?.Invoke(custId,typeDocument,fileName,comment);
        }

        private bool CtrlCabinet_OnSaveCustomerNeed(Customer customer)
        {
            return OnSaveCustomer?.Invoke(_customer) ?? false;
        }

        /// <summary>
        /// Встановлення джерела даних для гріда
        /// </summary>
        /// <param name="source">Об'єкт джерела даних</param>
        public void SetGridDataSource(IList<ConsumerBigRightView> source)
        {
            _brData = source;
            gvConsumerList.DataSource = _brData;
        }

        public void SetDataAnketaDictionaties(AnketaDictionaties aDictionaties)
        {
            _anketaDictionaties = aDictionaties;
        }

        public void SetDataCustomer(Customer customer)
        {
            _customer = customer;
        }

        public void SetBigRightBidAuthors(IList<object> authors)
        {
            var licDic = _customer.Client.LicenseAgreement.Where(rec=>rec.LicenseBigR!=null).Select(row=>row.LicenseBigR).ToDictionary(rec => rec.LicId);
            _authors = authors.Select( row =>
            {
                BigRightRequestBidAuthors item = (BigRightRequestBidAuthors) row;
                if (licDic.Keys.Contains(item.LicId))
                {
                    item.WorkRh = licDic[item.LicId].Obj?.CopyRight.First(rec => rec.CRightId == item.CRightId)?.WorkRh ?? new WorkRh
                    {
                        WorkTypeCl = default(int),
                        CRightId = item.CRightId
                    };
                }
                return item;
            }).ToList();
        }

        /// <summary>
        /// Дані для вкладки розрахунковий лист
        /// </summary>
        /// <param name="register"></param>
        public void SetPayslipsDate(IList<object> register, IList<object> spectacleView)
        {
            _registers = new List<BigRightRegister>();
            foreach (var temp in register)
                _registers.Add(temp as BigRightRegister);

            _payslipsSpectacleViews = new List<BigRightPayslipsSpectacleView>();
            foreach(var temp in spectacleView)
                _payslipsSpectacleViews.Add(temp as BigRightPayslipsSpectacleView);
        }

        public void SetMoneyUndescribsData(IList<object> moneyUndescribs)
        {
            _moneyUndescribs = new List<BigRightMoneyUndescrib>();
            foreach (var temp in moneyUndescribs)
                _moneyUndescribs.Add(temp as BigRightMoneyUndescrib);
        }

        /// <summary>
        /// Дані для вкладки заявки, грід заявок
        /// </summary>
        /// <param name="requestList"></param>
        public void SetRequestData(IList<object> requestList)
        {
            _requests = new List<BigRightRequests>();
            foreach (var temp in requestList)
                _requests.Add(temp as BigRightRequests);
        }

        /// <summary>
        /// Дані для вкладки довідки, грід заявок
        /// </summary>
        /// <param name="requestList"></param>
        public void SetReferanceData(IList<object> referanceList)
        {
            _reference = new List<BigRightRequests>();
            foreach (var temp in referanceList)
                _reference.Add(temp as BigRightRequests);
        }

        public void SetAgreementViewData(IList<object> agrData)
        {
            _agrData = new List<VbrLicense>();
            foreach (var temp in agrData)
                _agrData.Add(temp as VbrLicense);
        }

        public void SetAgrMasterList(IList<object> genAgrs)
        {
            _genAgrs = new List<BigRightMasterGenAgr>();
            foreach (var temp in genAgrs)
                _genAgrs.Add(temp as BigRightMasterGenAgr);
        }

        public void SetSelectCustomer(int custId)
        {
            if (gvConsumerList.Rows.Count != 0)
                gvConsumerList.CurrentRow = gvConsumerList.Rows.SingleOrDefault(rec => (int)rec.Cells["CustId"].Value == custId);
        }

        private void gvConsumerList_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if(gvConsumerList.Rows.Count == 0) return;
            
            _rowId = (int?)e?.CurrentRow?.Cells["CustId"]?.Value ?? -1;

            if(_rowId != -1)
            {
                //отримання даних
                OnCustomerUpdateDataNeed?.Invoke(_rowId);
                //передача даних
                ctrlCabinet.SetAndUpdateData(_customer,
                    e?.CurrentRow?.DataBoundItem as ConsumerBigRightView,
                    _agrData,
                    _genAgrs,
                    _requests,
                    _authors,
                    _reference,
                    _moneyUndescribs,
                    _registers,
                    _payslipsSpectacleViews);
            }
        }

        #region FILTERING (пошук)

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvConsumerList.MasterTemplate.Refresh();
        }

        private void gvConsumerList_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvConsumerList.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvConsumerList.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }

                gvConsumerList.EndUpdate(false);
                return;
            }

            //фільтр не пустий
            gvConsumerList.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvConsumerList.ColumnCount; i++)
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

                gvConsumerList.EndUpdate(false);
            }
        }

        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBackToGridNeed?.Invoke(_rowId);
        }

        private void btnNewConsumer_Click(object sender, EventArgs e)
        {
            OnAddNewCustomer?.Invoke(sender, e);
        }

        private void btnEditAgr_Click(object sender, EventArgs e)
        {
            OnEditCustomer?.Invoke(_rowId);
        }
    }
}
