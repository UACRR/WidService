using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    public partial class AnketaPersonRightholderPage : UserControl
    {
        public AnketaPersonRightholderPage()
        {
            InitializeComponent();
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object AnketaPersonDataSource
        {
            get => bsAnketaPerson.DataSource;
            set => bsAnketaPerson.DataSource = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object CustomerDataSource
        {
            get => bsCustomer.DataSource;
            set => bsCustomer.DataSource = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object RightholderDataSource
        {
            get => bsRightHolder.DataSource;
            set => bsRightHolder.DataSource = value;
        }

        public bool Validator()
        {
            return ctrlAnketaPerson.Validator() & ctrlRegistrationsPerson.Validator();
        }

        private void txtInterCode_Leave(object sender, EventArgs e)
        {
            // Тільки нові правовласники
            Customer cust = bsCustomer.DataSource as Customer;
            if (cust == null || cust.CustId != 0)
                return;

            IUniqueChecker checker = IpsGlobal.Instances[typeof(IUniqueChecker)] as IUniqueChecker;
            if (checker != null)
                lblIPIExists.Visible = !checker.CheckIPIIsUnique(txtInterCode.Text);
        }
    }
}
