using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class ProlongationAgreementForm : RadForm
    {
        private bool _changesSaved = false;
        private Customer _customer;
        private LicenseAgreement _license;
        private LicenseAgrParam _licAgr;
        private readonly AnketaDictionaties _dictionaties;
        private readonly DialogGoal _goal;
        
        public ProlongationAgreementForm(LicenseAgrParam bindAgr, AnketaDictionaties dictionaties, LicenseAgreement license, Customer customer, DialogGoal goal, TypeRights typeRights = TypeRights.SmallRights)
        {
        // * * * * * * * * 
            _license = license;
            _licAgr = bindAgr;
            _dictionaties = dictionaties;
            _customer = customer;
            _goal = goal;

            InitializeComponent();
            FormClosing += ProlongationWithPlaces_FormClosing;

            ctrlProlongation.OnSaveChangesClick += CtrlProlongation_OnSaveChangesClick;
            ctrlProlongation.Rights = typeRights;
            ctrlProlongation.Dictionaties = dictionaties; // словник

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

            var places = _customer.Client?.ClnBusinessPlace;
            ctrlProlongation.InitializeObjects(places, license, bindAgr, caType);
            ctrlProlongation.LicenseEnabled = goal == DialogGoal.forNew;

            // юр особа
            if (_customer.CustType == 3)
                ctrlProlongation.ClientName = _customer.Company.AnketaCompany.SingleOrDefault()?.ShortName;
            // фіз особа
            else if (_customer.CustType <= 2)
                ctrlProlongation.ClientName = _customer.Person?.AnketaPerson?.SingleOrDefault()?.LastName + _customer.Person?.AnketaPerson?.SingleOrDefault()?.FirstName;
        }
        private void CtrlProlongation_OnSaveChangesClick(object sender, EventArgs e)
        {
            _changesSaved = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CtrlProlongation_OnPrintClick()
        {
            var print = new ViewAndPrintAgreement(customer: _customer, licenseAgreement: _license)
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
                _license.LicenseAgrParam.Remove(_licAgr);
                _customer.Client.LicenseAgreement.Remove(_license);
            }

            if (_goal == DialogGoal.forProlongation)
            {
                _license.LicenseAgrParam.Remove(_licAgr);
            }
        }
    }
}
