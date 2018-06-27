using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class ProlongationWithPlaces : Telerik.WinControls.UI.RadForm
    {
        private bool _changesSaved = false;
        private LicenseAgreement _lic;
        private LicenseAgrParam _licAgr;
        private AnketaDictionaties _dict;
        private Customer _cust;

        public event EventHandler OnSaveProlongation;


        public ProlongationWithPlaces()
        {
            InitializeComponent();
        }

        public ProlongationWithPlaces(LicenseAgrParam bindAgr, AnketaCompany bindAnketaCompany, AnketaDictionaties dict,  string license, LicenseAgreement lic, ObservableListSource<ClnBusinessPlace> places, Customer cust)
        {
            _lic = lic;
            _licAgr = bindAgr;
            _dict = dict;
            _cust = cust;

            InitializeComponent(); // * * * 
            this.FormClosing += ProlongationWithPlaces_FormClosing;
            ctrlProlongation.OnPrintClick += CtrlProlongation_OnPrintClick;
            ctrlProlongation.OnSaveChangesClick += CtrlProlongation_OnSaveChangesClick;

            ctrlProlongation.InitializeObjects(cust, places, lic, bindAgr);

            ctrlProlongation.DataSourceGrid = places;

            ctrlProlongation.Dictionaties = dict;// словник

            ctrlProlongation.DataSourceAgreement = bindAgr;
            ctrlProlongation.DataSourceAnketaCompany = bindAnketaCompany;

            ctrlProlongation.LicenseName = license; // лбл ліцензії
            ctrlProlongation.LicenseAgrParam = bindAgr;
        }

        private void CtrlProlongation_OnSaveChangesClick()
        {
            _changesSaved = true;
            OnSaveProlongation?.Invoke(this, EventArgs.Empty);
            Close();
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

        private void ProlongationWithPlaces_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if(_changesSaved)
                return;

            _lic.LicenseAgrParam.Remove(_licAgr);
        }
    }
}
