using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.PartnerControls;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class CreatePartnerForm : Telerik.WinControls.UI.RadForm
    {
        private const string TitleJur = "Додавання нового представника (юридична особа)";
        private const string TitlePhis = "Додавання нового представника (фізична особа)";
        private PartnerAnketaPhisControl _phisControl = null;
        private PartnerAnketaJurControl _jurControl = null;
        private IAnketaControls _anketaControl;
        private Customer _customer;

        public CreatePartnerForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            DialogResult = DialogResult.None;
            // представник юридична особа
            if (customer.CustType == 3)
            {
                Text = TitleJur;
                _anketaControl = Architector.IncludeInstanceWhithReturn(this, _jurControl);
            }
            //представник фізична особа
            else if (customer.CustType == 1)
            {
                Text = TitlePhis;
                _anketaControl = Architector.IncludeInstanceWhithReturn(this, _phisControl);
            }

            _anketaControl.BeginBindings(_customer);
            _anketaControl.SaveClick += SaveClick;
        }

        private void SaveClick(object sender, bool accept)
        {
            if (accept && _customer != null)
            {
                // підтверджений представник
                _customer.Status = 2;
                _customer.AgreementMaster.SingleOrDefault().AgrStatus = 2;
                _customer.AgreementMaster.SingleOrDefault().AgreementAddPartner.SingleOrDefault().AgrStatus = 2;
                _customer.Person.AnketaPerson.SingleOrDefault().Status = 2;
            }
            DialogResult = DialogResult.OK;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }
        
    }
}
