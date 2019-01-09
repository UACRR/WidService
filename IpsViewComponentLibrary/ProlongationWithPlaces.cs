using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using License = ipsFormsDesign.Model.License;

namespace IpsViewComponentLibrary
{
    public partial class ProlongationWithPlaces : RadForm
    {
        private bool _changesSaved = false;
        private LicenseAgreement _lic;
        private LicenseAgrParam _licAgr;
        private AnketaDictionaties _dict;
        private Customer _cust;
        private readonly DialogGoal _goal;

        
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
            else if (goal == DialogGoal.forProlongation || goal == DialogGoal.forExistProlongation)
                caType = ConsumerAgreementInitType.Prolongation;
            else if (goal == DialogGoal.forChange || goal == DialogGoal.forExistChange)
                caType = ConsumerAgreementInitType.ChangeAgreement;

            ctrlProlongation.InitializeObjects(places, lic, bindAgr, caType);
            ctrlProlongation.LicenseEnabled = goal == DialogGoal.forNew;
        }

        private void CtrlProlongation_OnSaveChangesClick()
        {
            _changesSaved = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CtrlProlongation_OnPrintClick()
        {
            var print = new ViewAndPrintAgreement(dictionaties: _dict, customer: _cust, licenseAgreement: _lic)
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

            if (_goal == DialogGoal.forNew)
            {
                _lic.LicenseAgrParam.Remove(_licAgr);
                _cust.Client.LicenseAgreement.Remove(_lic);
            }

            if (_goal == DialogGoal.forProlongation)
            {
                _lic.LicenseAgrParam.Remove(_licAgr);
            }
        }
    }
}
