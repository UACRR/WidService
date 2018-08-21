using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class AddAuthRoleForMusDesingBr : Telerik.WinControls.UI.RadForm
    {
        private RegisterItem _registerItem = null;
        private Dictionary<int, CreativeRoleType> creativeDic;

        public object CreativeRoleDataSource
        {
            get => bsDictCreativeRole.DataSource;
            set => bsDictCreativeRole.DataSource = value;
        }

        public AddAuthRoleForMusDesingBr()
        {
            InitializeComponent();
            creativeDic = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1).ToDictionary(rec => rec.CodeI);
        }
        public AddAuthRoleForMusDesingBr(RegisterItem registerItem)
        {
            InitializeComponent();
            _registerItem = registerItem;
            creativeDic = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1).ToDictionary(rec => rec.CodeI);
            bsRegisterItem.DataSource = _registerItem;
        }

        private void gvAuthRole_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Row.DataBoundItem is RegisterExtra item)
            {
                registerExtraBindingSource.Remove(item);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAuthName.Text != string.Empty)
            {
                int roleCode = Convert.ToInt32(ddlCreativeRole.SelectedItem.Value ?? "0");
                var addRow = new RegisterExtra
                {
                    Name = txtAuthName.Text,
                    RoleCode = roleCode,
                    RoleCodeNavigation = creativeDic[roleCode]
                };

                registerExtraBindingSource.Add(addRow);
            }
            else
                MessageBox.Show("ПІБ автора не може бути пустим!", "Пусте поле", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCrName.Text != string.Empty)
            {
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Назва твору не може бути пустою!", "Пусте поле", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
