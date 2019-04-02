using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class AgreementActionsForm : RadForm
    {
        private Customer _customer;
        private LicenseAgreement _license;
        private LicenseAgrParam _licAgr;
        private readonly DialogGoal _goal;
        
        public AgreementActionsForm(LicenseAgrParam bindAgr, LicenseAgreement license, Customer customer, DialogGoal goal, TypeRights typeRights = TypeRights.SmallRights)
        {
            _license = license;
            _licAgr = bindAgr;
            _customer = customer;
            _goal = goal;

            InitializeComponent();
            FormClosing += ProlongationWithPlaces_FormClosing;

            ctrlProlongation.Rights = typeRights;

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
        }

        private void ProlongationWithPlaces_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                ctrlProlongation.UpdateLicenses();
                return;
            }

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
