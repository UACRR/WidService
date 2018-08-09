using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class CreateProgReportBigRight : Telerik.WinControls.UI.RadForm
    {
        private Register _register = null;
        private ObservableListSource<RegisterExtraGridSource> _gridSource = new ObservableListSource<RegisterExtraGridSource>();
        private RegisterItem _registerItemCreation = null, _registerItemMusDesign = null;
        public object RegisterDataSource
        {
            get => bsRegister.DataSource;
            set => bsRegister.DataSource = value;
        }

        public object CreativeRoleDataSource
        {
            get => bsDictCreativeRole.DataSource;
            set => bsDictCreativeRole.DataSource = value;
        }
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

        private void gvMusicalDesing_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            e.Row.DataBoundItem
        }

        private void gvStaging_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }

    internal class RegisterExtraGridSource
    {
        public int? RegId { get; set; }
        public int? RegItemId { get; set; }
        public int? RoleCode { get; set; }
        public string RoleName { get; set; }
        public string ItemName { get; set; }
    }
}
