using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            {"pvContacts" , CabinetTabType.Contacts},
            {"pvGeneralAgreement" , CabinetTabType.GeneralAgreement},
            {"pvFiles" , CabinetTabType.Files},
            {"pvAgent", CabinetTabType.Agent}
        };
        private Customer _customer = null;
        private ConsumerBigRightView _brView;
        private IList<VbrLicense> _brLicenses;
        private AnketaDictionaties _anketaDictionaties = null;
        private CabinetTabType _currenCabinetTab = CabinetTabType.Licenses;

        /// <summary>
        /// Виникиє при необхідності зберегти Customer
        /// </summary>
        public event EventHandler OnSaveCustomerNeed;

        public MiddleControlCabinet()
        {
            InitializeComponent();
        }

        public void SetDictionaries(AnketaDictionaties dictionaries)
        {
            _anketaDictionaties = dictionaries;
        }

        public void SetAndUpdateData(Customer customer, ConsumerBigRightView brView, IList<VbrLicense> brLicenses)
        {
            _customer = customer;
            _brView = brView;
            _brLicenses = brLicenses;
            UpdateCurentTab(_currenCabinetTab);
        }

        private void UpdateCurentTab(CabinetTabType tab)
        {
            switch (tab)
            {
                case CabinetTabType.None:
                    break;
                case CabinetTabType.Licenses:
                {
                    ctrlLicense.SetDataSources(_brView);
                    ctrlLicense.SetData(_customer,_brLicenses);
                }
                    break;
                case CabinetTabType.Calculations:
                    break;
                case CabinetTabType.Payslips:
                    break;
                case CabinetTabType.Requests:
                    break;
                case CabinetTabType.References:
                    break;
                case CabinetTabType.Contacts:
                    break;
                case CabinetTabType.GeneralAgreement:
                {
                    ctrlGeneralAgreement.SetAndUpdateData(_customer,_brView,_brLicenses);
                }
                    break;
                case CabinetTabType.Files:
                    break;
                case CabinetTabType.Agent:
                    break;
            }
        }

        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
            string tabName = ((Telerik.WinControls.UI.RadPageViewItem)((Telerik.WinControls.RadControl)sender).FocusedElement).Page.Name;
            _currenCabinetTab = _cabinetTab.SingleOrDefault(key => key.Key == tabName).Value;
            UpdateCurentTab(_currenCabinetTab);
        }
    }
}
