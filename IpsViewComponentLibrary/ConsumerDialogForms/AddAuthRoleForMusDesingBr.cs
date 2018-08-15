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
    public partial class AddAuthRoleForMusDesingBr : Telerik.WinControls.UI.RadForm
    {
        private RegisterItem _registerItem = null;
        private ObservableListSource<RegisterExtraGridSource> _gridSource = new ObservableListSource<RegisterExtraGridSource>();

        public object CreativeRoleDataSource
        {
            get => bsDictCreativeRole.DataSource;
            set => bsDictCreativeRole.DataSource = value;
        }

        public AddAuthRoleForMusDesingBr()
        {
            InitializeComponent();
        }
        public AddAuthRoleForMusDesingBr(RegisterItem registerItem)
        {
            InitializeComponent();
            _registerItem = registerItem;
        }

        private void gvAuthRole_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Row.DataBoundItem is RegisterExtraGridSource item)
                _gridSource.Remove(item);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAuthName.Text != string.Empty)
            {
                _gridSource.Add(new RegisterExtraGridSource
                {
                    Name = txtAuthName.Text,
                    RoleCode = Convert.ToInt32(ddlCreativeRole.SelectedItem.Value ?? "0"),
                    RoleName = ddlCreativeRole.SelectedItem.Text,
                });
                gvAuthRole.DataSource = _gridSource;
            }
            else
                MessageBox.Show("ПІБ автора не може бути пустим!", "Пусте поле", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCrName.Text != string.Empty)
            {
                _registerItem.ItemName = txtCrName.Text;
                foreach (var source in _gridSource)
                    _registerItem.RegisterExtra.Add((RegisterExtra)source);
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Назва твору не може бути пустою!", "Пусте поле", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
