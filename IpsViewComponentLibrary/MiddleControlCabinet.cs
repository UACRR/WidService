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
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinet : UserControl
    {
        private readonly Dictionary<string,CabinetTabType> _cabinetTab = new Dictionary<string, CabinetTabType>
        {
            {string.Empty, CabinetTabType.None},
            {"pvLicence" , CabinetTabType.Licenses},
            {"pvCalculation" , CabinetTabType.Calculations},
            {"pvPayslips" , CabinetTabType.Payslips},
            {"pvRequest" , CabinetTabType.Requests},
            {"pvReference" , CabinetTabType.References},
            {"pvGeneralAgreement" , CabinetTabType.GeneralAgreement},
            {"pvFiles" , CabinetTabType.Files},
            {"pvAgent", CabinetTabType.Agent},
            {"pvPays", CabinetTabType.Payments},
            {"pvAvances", CabinetTabType.Prepays},
            {"pvContacts", CabinetTabType.Contacts}
        };
        private Customer _customer = null;
        private ConsumerBigRightView _brView;
        private IList<VbrLicense> _brLicenses;
        private IList<BigRightMasterGenAgr> _genAgrs;
        private IList<BigRightRequests> _requests;
        private IList<BigRightRequests> _reference;
        private IList<BigRightRequestBidAuthors> _authors;
        private IList<BigRightMoneyUndescrib> _moneyUndescribs;
        private IList<BigRightRegister> _registers;
        private IList<BigRightPayslipsSpectacleView> _payslipsSpectacleViews;

        private AnketaDictionaties _anketaDictionaties = null;
        private CabinetTabType _currenCabinetTab = CabinetTabType.GeneralAgreement;

        /// <summary>
        /// Виникиє при необхідності зберегти Customer
        /// </summary>
        public event EventHandler OnSaveCustomerNeed;

        public event LisenseStatusChangeEventHandler OnLicenseStatusChanging;

        public event MiddleControlCabinetFiles.AddNewDocumentHandler OnAddNewDocument;
        public event MiddleControlCabinetFiles.ViewDocumentHandler OnViewDocumentNeed;
        public event MiddleControlCabinetPayslips.GetSpectacleView OnGetSpectacleNeed;

        public MiddleControlCabinet()
        {
            InitializeComponent();
            ctrlReference.SetAnketaDictionary(IpsGlobal.AnketaDictionaties);
            ctrlRequest.SetAnketaDictionary(IpsGlobal.AnketaDictionaties);
            ctrlReference.TypeControl = ControlRequestOrReferenceType.Reference;
            ctrlRequest.TypeControl = ControlRequestOrReferenceType.Request;
            ctrlFiles.OnAddNewDocument += CtrlFiles_OnAddNewDocument;
            ctrlFiles.OnViewDocButtonClick += CtrlFiles_OnViewDocButtonClick;
            ctrlPayslips.OnSpectacleViewNeed += CtrlPayslips_OnSpectacleViewNeed;
            ctrlGeneralAgreement.OnLicStatusChange += Ctrls_OnLicStatusChange;
        }

        private bool Ctrls_OnLicStatusChange(LicenseAgreement agr, int version, int status)
        {
            return OnLicenseStatusChanging?.Invoke(agr, version, status) ?? false;
        }

        private IList<BigRightSpectacleView> CtrlPayslips_OnSpectacleViewNeed(int custId)
        {
            return OnGetSpectacleNeed?.Invoke(custId);
        }

        private void CtrlFiles_OnViewDocButtonClick(int custId, int typeDocument, string fileName)
        {
            OnViewDocumentNeed?.Invoke(custId, typeDocument, fileName);
        }

        private void CtrlFiles_OnAddNewDocument(int custId, int typeDocument, string fileName, string comment)
        {
            OnAddNewDocument?.Invoke(custId, typeDocument, fileName, comment);
        }

        public void SetDictionaries(AnketaDictionaties dictionaries)
        {
            _anketaDictionaties = dictionaries;
        }

        public void SetAndUpdateData(Customer customer,
            ConsumerBigRightView brView,
            IList<VbrLicense> brLicenses,
            IList<BigRightMasterGenAgr> genAgrs,
            IList<BigRightRequests> requests,
            IList<BigRightRequestBidAuthors> authors,
            IList<BigRightRequests> reference,
            IList<BigRightMoneyUndescrib> moneyUndescribs,
            IList<BigRightRegister> registers,
            IList<BigRightPayslipsSpectacleView> payslipsSpectacleViews)
        {
            _customer = customer;
            _brView = brView;
            _brLicenses = brLicenses;
            _genAgrs = genAgrs;
            _requests = requests;
            _reference = reference;
            _authors = authors;
            _registers = registers;
            _moneyUndescribs = moneyUndescribs;
            _payslipsSpectacleViews = payslipsSpectacleViews;

            UpdateCurentTab(_currenCabinetTab);
        }



        private void UpdateCurentTab(CabinetTabType tab)
        {
            switch (tab)
            {
                case CabinetTabType.None:
                    break;

                case CabinetTabType.GeneralAgreement:
                {
                    ctrlGeneralAgreement.SetAndUpdateData(_customer, _brView, _genAgrs);
                }break;

                case CabinetTabType.Licenses:
                {
                    ctrlLicense.SetDataSources(_brView);
                    ctrlLicense.SetData(_customer,_brLicenses);
                }break;

                case CabinetTabType.Payslips:
                {
                    ctrlPayslips.SetAndUpdateData(_customer, _brView, _registers, _payslipsSpectacleViews);
                }break;

                case CabinetTabType.Calculations:
                {
                    ctrlCalculation.SetAndUpdateData(_customer, _brView, _genAgrs, _moneyUndescribs);
                }break;

                case CabinetTabType.Payments:
                {

                }break;

                case CabinetTabType.Prepays:
                {

                }break;

                case CabinetTabType.Requests:
                {
                    ctrlRequest.SetAndUpdateData(_customer,_brView,_requests,_authors);
                }break;

                case CabinetTabType.References:
                {
                    ctrlReference.SetAndUpdateData(_customer, _brView, _reference, _authors);
                }break;

                case CabinetTabType.Contacts:
                {
                    ctrlContactHeader.SetHeaderInfoBigRight(_customer,_brView);
                }break;

                case CabinetTabType.Files:
                {
                    ctrlFiles.SetAndUpdateData(_customer,_brView);
                }break;

                case CabinetTabType.Agent:
                {
                    ctrlAgent.SetAndUpdateData(_customer,_brView,_genAgrs);
                }break;
            }
        }

        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
            string tabName = ((Telerik.WinControls.UI.RadPageViewItem)((Telerik.WinControls.RadControl)sender).FocusedElement)?.Page?.Name ?? string.Empty;
            _currenCabinetTab = _cabinetTab.SingleOrDefault(key => key.Key == tabName).Value;
            UpdateCurentTab(_currenCabinetTab);
        }
    }
}
