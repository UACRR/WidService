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
        private DialogGoal _goal;
        public event EventHandler OnSaveProlongation;


        public ProlongationWithPlaces()
        {
            InitializeComponent();
        }
        
        public ProlongationWithPlaces(LicenseAgrParam bindAgr, 
                                      AnketaCompany bindAnketaCompany, 
                                      AnketaDictionaties dict, 
                                      LicenseAgreement lic, 
                                      ObservableListSource<ClnBusinessPlace> places, 
                                      Customer cust, 
                                      DialogGoal goal,
                                      TypeRights typeRights = TypeRights.SmallRights)
        {
        // * * * * * * * * 
            _lic = lic;
            _licAgr = bindAgr;
            _dict = dict;
            _cust = cust;
            _goal = goal;

            InitializeComponent(); // * * * 
            this.FormClosing += ProlongationWithPlaces_FormClosing;
            ctrlProlongation.OnPrintClick += CtrlProlongation_OnPrintClick;
            ctrlProlongation.OnSaveChangesClick += CtrlProlongation_OnSaveChangesClick;
            ctrlProlongation.Rights = typeRights;
            ctrlProlongation.Dictionaties = dict; // словник

            ConsumerAgreementInitType caType = ConsumerAgreementInitType.None;
            //ініціалізувати тип форми (пролонгація, додавання нового і т.д.)
            if (goal == DialogGoal.forNew)
                caType = ConsumerAgreementInitType.AddNewAgreement;
            else if (goal == DialogGoal.forEdit)
                caType = ConsumerAgreementInitType.EditAgreement;
            else if (goal == DialogGoal.forProlongation)
                caType = ConsumerAgreementInitType.Prolongation;

            ctrlProlongation.InitializeObjects(cust, places, lic, bindAgr, caType);

            ctrlProlongation.DataSourceAgreement = bindAgr;
            ctrlProlongation.DataSourceAnketaCompany = bindAnketaCompany;

            ctrlProlongation.LicenseAgrParam = bindAgr;

            ctrlProlongation.LicenseEnabled = goal == DialogGoal.forNew;
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

            if (_changesSaved)
                return;

            if (_goal != DialogGoal.forEdit)
            {
                _lic.LicenseAgrParam.Remove(_licAgr);
                _cust.Client.LicenseAgreement.Remove(_lic);
            }
        }
    }
}
