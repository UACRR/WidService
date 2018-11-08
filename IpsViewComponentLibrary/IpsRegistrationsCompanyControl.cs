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
using IpsViewComponentLibrary.Utilities;
using ipsFormsDesign.Data;

namespace IpsViewComponentLibrary
{
    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class IpsRegistrationsCompanyControl : UserControl
    {        
        public IpsRegistrationsCompanyControl()
        {
            InitializeComponent();
            dtRegisterDate.SetUserCalendarSettingsm();

            if (!IsDesignMode)
            {
                SetDictionaries();
            }
        }

        private void SetDictionaries()
        {
            ddlTypeVat.SetDataSource(IpsGlobal.AnketaDictionaties.typeVat);
        }

        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => bsAnketaCompany.DataSource;
            set
            {
                if (bsAnketaCompany.DataSource != value)
                    bsAnketaCompany.DataSource = value;
            }
        }

        #region Edit controls

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtOkpo => txtOkpo;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtRegisterNumber => txtRegisterNumber;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDateTimePicker DtRegisterDate => dtRegisterDate;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtRegisterWho => txtRegisterWho;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtNumberVat => txtNumberVat;

        #endregion

        public bool Validator()
        {
            bool isValid = true;

            if (txtOkpo.Text == string.Empty)
            {
                lbledrpou.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lbledrpou.ForeColor = Color.Black;

            if (txtRegisterNumber.Text == string.Empty)
            {
                lblSvidoctvo.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblSvidoctvo.ForeColor = Color.Black;

            //if (txtRegisterWho.Text == string.Empty)
            //{
            //    lblIssuedBy.ForeColor = Color.FromArgb(180, 255, 0, 2);
            //    isValid = false;
            //}
            //else
            //    lblIssuedBy.ForeColor = Color.Black;

            return isValid;
        }
        
        private void ddlTypeVat_SelectedValueChanged(object sender, EventArgs e)
        {

            if (ddlTypeVat.SelectedValue == null)
                return;

            if (ddlTypeVat.SelectedValue.ToString() == "2")
            {
                lblIPN.Enabled = false;
                txtNumberVat.Enabled = false;

            }
            if (ddlTypeVat?.SelectedValue?.ToString() == "1")
            {
                 lblIPN.Enabled = true;
                txtNumberVat.Enabled = true;
            }
        }

        private void txtOkpo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void txtNumberVat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
