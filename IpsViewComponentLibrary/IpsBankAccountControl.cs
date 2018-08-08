using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary
{
    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class IpsBankAccountControl : UserControl
    {
        public IpsBankAccountControl()
        {
            InitializeComponent();
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get { return bsBankAccount.DataSource; }
            set
            {
                if (bsBankAccount.DataSource != value)
                    bsBankAccount.DataSource = value;
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string DataMember
        {
            get { return bsBankAccount.DataMember; }
            set { bsBankAccount.DataMember = value; }
        }

        #region Edit controls

        public RadTextBox TxtMfo
        {
            get
            {
                return txtMfo;
            }
        }

        public RadTextBox TxtMfoName
        {
            get
            {
                return txtMfoName;
            }
        }

        public RadTextBox TxtMfoOkpo
        {
            get
            {
                return txtMfoOkpo;
            }
        }

        public RadTextBox TxtTransitNumber
        {
            get
            {
                return txtTransitNumber;
            }
        }

        public RadTextBox TxtAccountNumber
        {
            get
            {
                return txtAccountNumber;
            }
        }

        public bool Validator()
        {
            bool isValid = true;

            //if (rtxtBoxAuthorPaymentPercent.Text == string.Empty)
            //{
            //    isValid = false;
            //    radLabel1.ForeColor = Color.FromArgb(180, 255, 0, 2); ;
            //}
            //else
            //    radLabel1.ForeColor = Color.Black;

            return isValid;
        }

        #endregion

        private void txtMfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void txtMfoOkpo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
