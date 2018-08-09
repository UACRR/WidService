using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class CreateProgReportBigRight : Telerik.WinControls.UI.RadForm
    {
        private Register _register = null;
        private RegisterItem _registerItemCreation = null, _registerItemMusDesign = null;
        public CreateProgReportBigRight()
        {
            InitializeComponent();
        }

        public CreateProgReportBigRight(Register register)
        {
            InitializeComponent();
            _register = register;
            _registerItemCreation = new RegisterItem
            {
                CodeItem = 2,
            };
            _register.RegisterItem.Add(_registerItemCreation);
        }

        public object RegisterDataSource
        {
            get => bsRegister.DataSource;
            set => bsRegister.DataSource = value;
        }

        private void btnAddCreativeRole_Click(object sender, EventArgs e)
        {

        }

        private void btnAddRegItem_Click(object sender, EventArgs e)
        {
            _registerItemMusDesign = new RegisterItem
            {
                CodeItem = 3,
            };
            _register.RegisterItem.Add(_registerItemMusDesign);
            AddAuthRoleForMusDesingBr addAuthRole = new AddAuthRoleForMusDesingBr(_registerItemMusDesign);
            if (addAuthRole.ShowDialog() == DialogResult.OK)
            {

            }
            else
                _register.RegisterItem.Remove(_registerItemMusDesign);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
