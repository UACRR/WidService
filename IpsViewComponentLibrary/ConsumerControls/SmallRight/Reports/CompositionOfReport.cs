using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight.Reports
{
    public partial class CompositionOfReport : RadForm
    {

        public CompositionOfReport(RegisterItem registerItem)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            ctrlSaveCancelButtons.ButtonSaveDialogResult = DialogResult.None;
            ctrlSaveCancelButtons.SaveClck += btnSave_Click;
            bsDictCreativeRole.DataSource = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1);
            bsDictGenreType.DataSource = IpsGlobal.AnketaDictionaties.genreType.Where(rec => rec.CategoryCode == 5);
            bsRegisterItem.DataSource = registerItem;
        }

        private void gvAuthRole_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (!(e.Row.DataBoundItem is RegisterExtra item))
                return;

            bsRegisterExtra.Remove(item);
            bsRegisterExtra.ResetBindings(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gvAuthRole.Rows.AddNew();
            gvAuthRole.CurrentRow.Cells[0].BeginEdit();
            

            //if (string.IsNullOrEmpty(txtAuthName.Text))
            //{
            //    MessageBox.Show("ПІБ автора не може бути пустим!", "Пусте поле", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //int roleCode = Convert.ToInt32(ddlCreativeRole.SelectedItem.Value ?? "0");
            //var addRow = new RegisterExtra
            //{
            //    Name = txtAuthName.Text,
            //    RoleCode = roleCode,
            //    RoleCodeNavigation = (bsDictCreativeRole.DataSource as IEnumerable<CreativeRoleType>)?.ToDictionary(rec => rec.CodeI)[roleCode],
            //};

            //bsRegisterExtra.Add(addRow);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCrName.Text))
            {
                MessageBox.Show("Назва твору не може бути пустою!", "Пусте поле", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ClearEmptyRowData();
            DialogResult = DialogResult.OK;
        }

        private void ClearEmptyRowData()
        {

        }
    }
}
