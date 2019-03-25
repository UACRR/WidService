using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Shared.Controls
{
    [ComplexBindingProperties("DataSource")]
    public partial class IpsRegistrationsCompanyControl : UserControl
    {
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public IpsRegistrationsCompanyControl()
        {
            InitializeComponent();
            dtRegisterDate.SetUserCalendarSettingsm();
            txtOkpo.KeyPress += ExtensionUtils.TextBoxNumeric_KeyPressEvent;
            txtNumberVat.KeyPress += ExtensionUtils.TextBoxNumeric_KeyPressEvent;

            if (!IsDesignMode)
                ddlTypeVat.SetDataSource(IpsGlobal.AnketaDictionaties.typeVat);
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
            bool isValid = !lblOKPOExists.Visible;

            if (txtOkpo.Text == string.Empty)
            {
                lbledrpou.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lbledrpou.ForeColor = Color.Black;

            //if (txtRegisterNumber.Text == string.Empty)
            //{
            //    lblSvidoctvo.ForeColor = Color.FromArgb(180, 255, 0, 2);
            //    isValid = false;
            //}
            //else
            //    lblSvidoctvo.ForeColor = Color.Black;

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
            if (!int.TryParse(ddlTypeVat?.SelectedValue?.ToString(), out int typeVat))
                return;

            lblIPN.Enabled = typeVat == 1;
            txtNumberVat.Enabled = typeVat == 1;
        }

        private void txtOkpo_Leave(object sender, EventArgs e)
        {
            // Тільки нові правовласники
            var cust = bsAnketaCompany.DataSource is AnketaCompany company ? company 
                : (bsAnketaCompany.DataSource as BindingSource)?.Current as AnketaCompany;

            if (cust != null && (cust.CustId != 0 && string.IsNullOrEmpty(cust.Okpo) == false && cust.Okpo.Trim() == txtOkpo.Text.Trim() ) )
                return;

            if (!IpsGlobal.Instances.Keys.Contains(typeof(IUniqueChecker)))
                return; 

            IUniqueChecker checker = IpsGlobal.Instances[typeof(IUniqueChecker)] as IUniqueChecker;
            if (checker != null)
                lblOKPOExists.Visible = !checker.CheckOKPOIsUnique(txtOkpo.Text, cust.CustId );
        }
    }
}
