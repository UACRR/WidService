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

        public void SetCustomer(Customer customer)
        {
            _customer = customer;
            UpdateCurentTab(_currenCabinetTab);
        }

        private void UpdateCurentTab(CabinetTabType tab)
        {
            switch (tab)
            {
                case CabinetTabType.None:
                    break;
                case CabinetTabType.Licenses:
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
