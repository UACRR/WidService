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

namespace IpsViewComponentLibrary
{
    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class IpsRegistrationsCompanyControl : UserControl
    {
        // BindingSource iAnketaCompanyBindingSource;
        string _okpoDataMember;
        string _registerNumberDataMember;
        string _registerDateDataMember;
        string _registerWhoDataMember;
        private string _typeVatDataMember;

        string _numberVatDataMember;
        
        public IpsRegistrationsCompanyControl()
        {
            InitializeComponent();
            dtRegisterDate.SetUserCalendarSettingsm();
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get { return iAnketaCompanyBindingSource.DataSource; }
            set
            {
                if (iAnketaCompanyBindingSource.DataSource != value)
                    iAnketaCompanyBindingSource.DataSource = value;
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string DataMember
        {
            get { return iAnketaCompanyBindingSource.DataMember; }
            set { iAnketaCompanyBindingSource.DataMember = value; }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string OkpoDataMember
        {
            get { return _okpoDataMember; }
            set
            {
                if (_okpoDataMember != value)
                {
                    _okpoDataMember = value;
                    txtOkpo.DataBindings.Clear();
                    txtOkpo.DataBindings.Add("Text", iAnketaCompanyBindingSource, _okpoDataMember);
                }
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string RegisterNumberDataMember
        {
            get { return _registerNumberDataMember; }
            set
            {
                if (_registerNumberDataMember != value)
                {
                    _registerNumberDataMember = value;
                    txtRegisterNumber.DataBindings.Clear();
                    txtRegisterNumber.DataBindings.Add("Text", iAnketaCompanyBindingSource, _registerNumberDataMember);
                }
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string RegisterDateDataMember
        {
            get { return _registerDateDataMember; }
            set
            {
                if (_registerDateDataMember != value)
                {
                    _registerDateDataMember = value;
                    dtRegisterDate.DataBindings.Clear();
                    dtRegisterDate.DataBindings.Add("Value", iAnketaCompanyBindingSource, _registerDateDataMember,true);
                }
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string RegisterWhoDataMember
        {
            get { return _registerWhoDataMember; }
            set
            {
                if (_registerWhoDataMember != value)
                {
                    _registerWhoDataMember = value;
                    txtRegisterWho.DataBindings.Clear();
                    txtRegisterWho.DataBindings.Add("Text", iAnketaCompanyBindingSource, _registerWhoDataMember);
                }
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string TypeVatDataMember
        {
            get => _typeVatDataMember;
            set
            {
                if (_typeVatDataMember != value)
                {
                    _typeVatDataMember = value;
                    ddlTypeVat.DataBindings.Clear();
                    ddlTypeVat.DataBindings.Add("SelectedValue", iAnketaCompanyBindingSource, "TypeVat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, string.Empty);
                }
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string NumberVatDataMember
        {
            get => _numberVatDataMember;
            set
            {
                if (_numberVatDataMember != value)
                {
                    _numberVatDataMember = value;
                    txtNumberVat.DataBindings.Clear();
                    txtNumberVat.DataBindings.Add("Text", iAnketaCompanyBindingSource, _numberVatDataMember,true,DataSourceUpdateMode.OnPropertyChanged,string.Empty);
                }
            }
        }

        #region Type VAT dictionary

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object TypesVatDataSource
        {
            get { return ddlTypeVat.DataSource; }
            set
            {
                if (ddlTypeVat.DataSource != value)
                    ddlTypeVat.DataSource = value;
            }
        }

        [Category("Dictionaries")]
        public string TypesVatDataMember
        {
            get { return ddlTypeVat.DataMember; }
            set { ddlTypeVat.DataMember = value; }
        }

        [Category("Dictionaries")]
        public string TypesVatDisplayMember
        {
            get { return ddlTypeVat.DisplayMember; }
            set { ddlTypeVat.DisplayMember = value; }
        }

        [Category("Dictionaries")]
        public string TypesVatValueMember
        {
            get { return ddlTypeVat.ValueMember; }
            set { ddlTypeVat.ValueMember = value; }
        }


        #endregion

        #region Edit controls

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtOkpo
        {
            get
            {
                return txtOkpo;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtRegisterNumber
        {
            get
            {
                return txtRegisterNumber;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDateTimePicker DtRegisterDate
        {
            get
            {
                return dtRegisterDate;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtRegisterWho
        {
            get
            {
                return txtRegisterWho;
            }
        }

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //public RadDropDownList DdlTypeVat
        //{
        //    get
        //    {
        //        return ddlTypeVat;
        //    }
        //}

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtNumberVat
        {
            get
            {
                return txtNumberVat;
            }
        }

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

            if (txtRegisterWho.Text == string.Empty)
            {
                lblIssuedBy.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblIssuedBy.ForeColor = Color.Black;

            //if (txtNumberVat.Text == string.Empty)
            //{
            //    lblIPN.ForeColor = Color.FromArgb(180, 255, 0, 2);
            //    isValid = false;
            //}
            //else
            //    lblIPN.ForeColor = Color.Black;

            return isValid;
        }

        public void ClearData()
        {
            txtNumberVat.Text = string.Empty;
            txtOkpo.Text = string.Empty;
            txtRegisterNumber.Text = string.Empty;
            txtRegisterWho.Text = string.Empty;
            dtRegisterDate.Text = string.Empty;
        }


        private void ddlTypeVat_SelectedValueChanged(object sender, EventArgs e)
        {
             if(ddlTypeVat.SelectedValue.ToString() == "2")
             {
                lblIPN.Enabled = false;
                txtNumberVat.Enabled = false;
                //txtNumberVat.Clear();
            }
             if(ddlTypeVat.SelectedValue.ToString() == "1")
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

        internal void SetDefaultState()
        {
            if (ddlTypeVat.Items.Count != 0)
            {
                ddlTypeVat.SelectedIndex = ddlTypeVat.Items.Last.Index;
                ddlTypeVat.SelectedIndex = ddlTypeVat.Items.First.Index;
            }
        }
    }
}
