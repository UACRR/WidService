using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class ProlongationWithoutPlaces : Telerik.WinControls.UI.RadForm
    {
        private bool _changesSaved = false;
        private LicenseAgreement _lic;
        private AnketaDictionaties _dict;
        private Customer _cust;
        private LicenseAgrParam _licAgr;

        public event EventHandler OnSaveProlongation;

        public ProlongationWithoutPlaces()
        {
            InitializeComponent();
        }

        //TODO: переробити databinding LicenseAgrParam
        public ProlongationWithoutPlaces(LicenseAgrParam bindAgr, AnketaCompany bindAnketaCompany, AnketaDictionaties dict, string license, LicenseAgreement lic, Customer customer, DialogGoal goal)
        {
            _lic = lic;
            _licAgr = bindAgr;
            _dict = dict;
            _cust = customer;
            InitializeComponent();
            this.FormClosing += ProlongationWithoutPlaces_FormClosing;
            ctrlProlongation.OnSaveChangesClick += CtrlProlongation_OnSaveChangesClick;
            ctrlProlongation.OnPrintClick += CtrlProlongation_OnPrintClick;

            ctrlProlongation.Dictionaties = dict;// словник

            ctrlProlongation.DataSourceAgreement = bindAgr; 
            ctrlProlongation.DataSourceAnketaCompany = bindAnketaCompany;

            ctrlProlongation.LicenseName = license; // лбл ліцензії
            ctrlProlongation.LicenseAgrParam = bindAgr;
            
        }

        private void CtrlProlongation_OnPrintClick()
        {
            ViewAndPrintAgreement print = new ViewAndPrintAgreement(dictionaties: _dict, customer: _cust, licenseAgreement: _lic)
            {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen
            };
            print.ShowDialog();
        }

        private void CtrlProlongation_OnSaveChangesClick()
        {
            _changesSaved = true;
            OnSaveProlongation?.Invoke(this,EventArgs.Empty);
            Close();
        }

        private void ProlongationWithoutPlaces_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_changesSaved)
                return;

            _lic.LicenseAgrParam.Remove(_licAgr);
        }
    }
}
