using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class CompositionOfReport : RadForm
    {
        private readonly Dictionary<int, CreativeRoleType> creativeDic;

        public object CreativeRoleDataSource
        {
            get => bsDictCreativeRole.DataSource;
            set => bsDictCreativeRole.DataSource = value;
        }

        public CompositionOfReport(RegisterItem registerItem)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            ctrlSaveCancelButtons.ButtonSaveDialogResult = DialogResult.None;
            ctrlSaveCancelButtons.SaveClck += btnSave_Click;
            creativeDic = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1).ToDictionary(rec => rec.CodeI);
            bsRegisterItem.DataSource = registerItem;
        }

        private void gvAuthRole_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Row.DataBoundItem is RegisterExtra item)
                registerExtraBindingSource.Remove(item);   
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAuthName.Text))
            {
                MessageBox.Show("ПІБ автора не може бути пустим!", "Пусте поле", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int roleCode = Convert.ToInt32(ddlCreativeRole.SelectedItem.Value ?? "0");
            var addRow = new RegisterExtra
            {
                Name = txtAuthName.Text,
                RoleCode = roleCode,
                RoleCodeNavigation = creativeDic[roleCode]
            };

            registerExtraBindingSource.Add(addRow);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCrName.Text))
            {
                MessageBox.Show("Назва твору не може бути пустою!", "Пусте поле", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
